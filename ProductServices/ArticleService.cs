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

        /// <summary>
        /// Get Single Article
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ArticleSingleModel GetSingleArticle(int id)
        {
            _articleEntity = _repository.Find(id);
            ArticleSingleModel temp = connectedMapper.Map<ArticleSingleModel>(_articleEntity);
            return temp;
        }

        /// <summary>
        /// Get total article sum
        /// </summary>
        /// <returns>Return sum of article</returns>
        public int GetCount()
        {
            return _repository.ArticlesCount();
        }

        /// <summary>
        /// prepare save article
        /// </summary>
        /// <param name="model">Need ArticleNewModel</param>
        /// <returns>Return article Id</returns>
        public int Add(ArticleNewModel model)
        {
            _articleEntity = connectedMapper.Map<Article>(model);
            _articleEntity.PublishArticle();
            _articleEntity.Author = CurrenUser;

            SaveKeyword(model.Keywords);

            //Add Bmoney
            _articleEntity.Author.Wallet = new List<BMoney>();
            _articleEntity.Author.Wallet.Add(
                new BMoney().PublicArticleMinusBMoney(
                    new BMoneyRepository(dbContext).GetByAuthorBMoney(CurrentUserId)));

            return _repository.AddArticleToDatabase(_articleEntity);
        }

        /// <summary>
        /// For change article content
        /// </summary>
        /// <param name="model">Need articleEditModel</param>
        public void Update(AritcleEditModel model)
        {
            _articleEntity = _repository.GetEditArticle(model.Id);
            _articleEntity.OwnKeyword.Clear();
            connectedMapper.Map(model, _articleEntity);
            SaveKeyword(model.Keywords);

        }

        private void SaveKeyword(string Keywords)
        {
            _articleEntity.OwnKeyword = new List<KeywordsAndArticle>();
            IList<Keywords> keywords = new Keywords().GetKeywordList(Keywords);
            Keywords checkExist = new Keywords();
            foreach (var item in keywords)
            {
                checkExist = new KeywordRepository(dbContext).FindKeyword(item.Name);
                if (checkExist == null)
                {
                    _articleEntity.OwnKeyword.Add(new KeywordsAndArticle
                    { Article = _articleEntity, Keyword = new Keywords { Name = item.Name, Used = 1 } });
                }
                else
                {
                    checkExist.Used += 1;
                    _articleEntity.OwnKeyword.Add(new KeywordsAndArticle
                    { Article = _articleEntity, Keyword = checkExist });
                }
            }
        }


        public AritcleEditModel GetEditArticle(int? id)
        {
            _articleEntity = _repository.GetEditArticle(id);

            AritcleEditModel articleEditModel = new AritcleEditModel();
            articleEditModel = connectedMapper.Map<AritcleEditModel>(_articleEntity);

            articleEditModel.Author = _articleEntity.Author.UserName;
            articleEditModel.WebSite = _articleEntity.UseAd.WebSite;
            articleEditModel.ContentOfAd = _articleEntity.UseAd.ContentOfAd;

            var keywords = new KeywordAndArticleRepository(dbContext).GetKeywords(id.Value);
            string keyWordOfArticle = string.Empty;
            foreach (var item in keywords)
            {
                keyWordOfArticle += item.Keyword.Name + " ";
            }
            articleEditModel.Keywords = keyWordOfArticle;
            return articleEditModel;
        }

        public ArticleIndexModel GetArticles(int pageSize, int pageIndex)
        {
            IList<Article> tempArticle = new List<Article>();
            IList<KeywordsAndArticle> tempKeywords = new List<KeywordsAndArticle>();

            tempArticle = _repository.GetArticles(pageSize, pageIndex);
            ArticleIndexModel articleIndex = new ArticleIndexModel
            {
                Items = connectedMapper.Map<List<ArticleItemsModel>>(tempArticle),
            };
            return articleIndex;
        }
    }
}
