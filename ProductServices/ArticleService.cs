using EntityMVC;
using RepositoryMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ViewModel;
using ViewModel.Article;

namespace ProductServices
{
    public class ArticleService : BaceService
    {
        /// Infact I wanna use this function ,but when IList<T> inside i can't point something...faild
        public IList<SelectListItem> GetDropDownList<T>(IList<T> ts)
        {
            List<SelectListItem> dropDownList = new List<SelectListItem>();
            foreach (var item in ts)
            {
                dropDownList.Add(new SelectListItem { Text = item.ToString(), Value = item.ToString() });
            }
            return dropDownList;
        }

        public int GetCount()
        {
            return new ArticleRepository(dbContext).ArticlesCount();
        }

        public int Add(ArticleNewModel model)
        {
            int articleId = 0;
            Article _articleEntity = new Article();
            {
                Article article = connectedMapper.Map<Article>(model);
                if (string.IsNullOrEmpty(model.Summary))
                {
                    article.Summary = _articleEntity.GetSumarry(model.Body);
                }
                _articleEntity.PublishArticle(article);
                article.Author = new UserRepository(dbContext).Find(CurrentUserId);

                //Get and save series with AD to article foregin key.
                article.UseSeries = new SeriesRepository(dbContext).GetSeries(model.ChoosSeries);
                article.UseAd = new ADRepository(dbContext).GetAD(model.ChoosAd);
                articleId = new ArticleRepository(dbContext).AddArticleToDatabase(article);
                dbContext.SaveChanges();
                articleId = new ArticleRepository(dbContext).Find(model.Title);
            }
            {
                //Save keywords and into n:n table.
                IList<Keywords> keywords = new Keywords().GetKeywordList(model.Keywords);
                KeywordRepository keywordRepository = new KeywordRepository(dbContext);
                foreach (var item in keywords)
                {
                    int keywordId = 0;
                    Keywords temp = keywordRepository.GetByKeyword(item);
                    if (temp == null)
                    {
                        Keywords tempAdd = new Keywords();
                        tempAdd = tempAdd.AddNewKeyword(item);
                        keywordId = keywordRepository.AddKeywordToDatabase(tempAdd);
                        dbContext.SaveChanges();
                        keywordId = new KeywordRepository(dbContext).Find(item.Name);
                    }
                    else
                    {
                        temp = temp.AddUsed(temp);
                        keywordId = keywordRepository.UpdateKeywordUsed(temp);
                    }

                    new KeywordAndArticleRepository(dbContext).AddDatabase(articleId, keywordId);
                    dbContext.SaveChanges();

                }
            }
            {
                ///Minus article author BMoney
                BMoney money = new BMoney();
                BMoneyRepository bMoneyRepository = new BMoneyRepository(dbContext);
                money = money.PublicArticleMinusBMoney(bMoneyRepository.GetByAuthorBMoney(CurrentUserId));
                bMoneyRepository.AddNewRow(money);
                dbContext.SaveChanges();
            }
            return articleId;
        }

        public void Update(ArticleNewModel model)
        {
            {
                var articleRepo = new ArticleRepository(dbContext);
                Article article = new Article();
                article = articleRepo.GetEditArticle(model.Id);
                if (string.IsNullOrEmpty(model.Summary))
                {
                    article.Summary = article.GetSumarry(model.Body);
                }
                article.Title = model.Title;
                article.Body = model.Body;
                article.UseSeries = new SeriesRepository(dbContext).GetSeries(model.ChoosSeries);
                article.UseAd = new ADRepository(dbContext).GetAD(model.ChoosAd);
                articleRepo.UpdateEditArticle(article);
                dbContext.SaveChanges();
            }
            {
                //Save keywords and into n:n table.
                var middleTable = new KeywordAndArticleRepository(dbContext);
                middleTable.DeleteOldRelation(model.Id);

                IList<Keywords> keywords = new Keywords().GetKeywordList(model.Keywords);
                KeywordRepository keywordRepository = new KeywordRepository(dbContext);
                foreach (var item in keywords)
                {
                    int keywordId = 0;
                    Keywords temp = keywordRepository.GetByKeyword(item);
                    if (temp == null)
                    {
                        Keywords tempAdd = new Keywords();
                        tempAdd = tempAdd.AddNewKeyword(item);
                        keywordId = keywordRepository.AddKeywordToDatabase(tempAdd);
                        dbContext.SaveChanges();
                        keywordId = new KeywordRepository(dbContext).Find(item.Name);
                    }
                    else
                    {
                        temp = temp.AddUsed(temp);
                        keywordId = keywordRepository.UpdateKeywordUsed(temp);
                    }

                    middleTable.AddDatabase(model.Id, keywordId);
                    dbContext.SaveChanges();

                }
            }
        }

        public AritcleEditModel GetEditArticle(int? id)
        {
            Article article = new ArticleRepository(dbContext).GetEditArticle(id);
            AritcleEditModel articleEditModel = new AritcleEditModel();
            articleEditModel = connectedMapper.Map<AritcleEditModel>(article);
            articleEditModel.Author = article.Author.UserName;
            articleEditModel.ChoosAd = article.UseAd.Id;
            articleEditModel.WebSite = article.UseAd.WebSite;
            articleEditModel.ContentOfAd = article.UseAd.ContentOfAd;
            articleEditModel.ChoosSeries = article.UseSeries.Id;

            var keywords = new KeywordAndArticleRepository(dbContext).GetKeywords(id.Value);
            string keyWordOfArticle = string.Empty;
            foreach (var item in keywords)
            {
                keyWordOfArticle = item.Keyword.Name + " ";
            }
            articleEditModel.Keywords = keyWordOfArticle;
            return articleEditModel;
        }

        public ArticleIndexModel GetArticles()
        {
            IList<Article> tempArticle = new List<Article>();
            IList<KeywordsAndArticle> tempKeywords = new List<KeywordsAndArticle>();


            tempArticle = new ArticleRepository(dbContext).GetArticles();
            ArticleIndexModel articleIndex = new ArticleIndexModel
            {
                Items = connectedMapper.Map<List<ArticleItemsModel>>(tempArticle),
            };

            articleIndex.ListKeywords = new List<KeywordsModel>();
            foreach (var articleItem in tempArticle)
            {
                articleIndex.Author = articleItem.Author.UserName;
                articleIndex.Level = articleItem.Author.Level;
                articleIndex.Id = articleItem.Author.Id;
                tempKeywords = new KeywordAndArticleRepository(dbContext).GetKeywords(articleItem.Id);

                foreach (var keywordsItem in tempKeywords)
                {
                    articleIndex.ListKeywords.Add(new KeywordsModel
                    {
                        Name = keywordsItem.Keyword.Name
                    });
                }
            }




            return articleIndex;
        }
    }
}
