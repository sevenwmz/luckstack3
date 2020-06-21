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
        private ArticleRepository _repository;
        private Article _articleEntity;
        public ArticleService()
        {
            _repository = new ArticleRepository(dbContext);
            _articleEntity = new Article();
        }


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
            return _repository.ArticlesCount();
        }

        public int Add(ArticleNewModel model)
        {
            Article _articleEntity = new Article();

            Article article = connectedMapper.Map<Article>(model);
            if (string.IsNullOrEmpty(model.Summary))
            {
                article.Summary = _articleEntity.GetSumarry(model.Body);
            }
            _articleEntity.PublishArticle(article);
            article.Author = new UserRepository(dbContext).Find(CurrentUserId);

            //Get and save series with AD to article foregin key.
            article.UseSeries.Id = new SeriesRepository(dbContext).GetSeries(model.ChoosSeries);
            article.UseAd.Id = new ADRepository(dbContext).GetAD(model.ChoosAd);
            int articleId = _repository.AddArticleToDatabase(article);

            {
                //Save keywords
                new KeywordsService().SaveKeywords(articleId, model);
            }
            {
                ///Minus article author BMoney
                BMoney money = new BMoney();
                BMoneyRepository bMoneyRepository = new BMoneyRepository(dbContext);
                money = money.PublicArticleMinusBMoney(bMoneyRepository.GetByAuthorBMoney(CurrentUserId));
                bMoneyRepository.AddNewRow(money);
            }
            return articleId;
        }
        /// <summary>
        /// For change article content
        /// </summary>
        /// <param name="model">Need articleEditModel</param>
        public void Update(AritcleEditModel model)
        {
            {
                _articleEntity = _repository.GetEditArticle(model.Id);
                if (string.IsNullOrEmpty(model.Summary))
                {
                    _articleEntity.Summary = _articleEntity.GetSumarry(model.Body);
                }
                _articleEntity.Title = model.Title;
                _articleEntity.Body = model.Body;
                _articleEntity.UseSeries.Id = new SeriesRepository(dbContext).GetSeries(model.ChoosSeries);
                _articleEntity.UseAd.Id = new ADRepository(dbContext).GetAD(model.ChoosAd);
                _repository.UpdateEditArticle(_articleEntity);
            }
            {
                //Save keywords and into n:n table.
                new KeywordAndArticleService().DeleteOldRelation(model.Id);
                new KeywordsService().SaveKeywords(model.Id,model);
            }
        }

        public AritcleEditModel GetEditArticle(int? id)
        {
            _articleEntity = _repository.GetEditArticle(id);

            AritcleEditModel articleEditModel = new AritcleEditModel();
            articleEditModel = connectedMapper.Map<AritcleEditModel>(_articleEntity);

            articleEditModel.Author = _articleEntity.Author.UserName;
            articleEditModel.ChoosAd = _articleEntity.UseAd.Id;
            articleEditModel.WebSite = _articleEntity.UseAd.WebSite;
            articleEditModel.ContentOfAd = _articleEntity.UseAd.ContentOfAd;
            articleEditModel.ChoosSeries = _articleEntity.UseSeries.Id;

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


            tempArticle = _repository.GetArticles();
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
