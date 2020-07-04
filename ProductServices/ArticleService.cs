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

        public ArticleCategoryModel GetAuthorCategory(int id, bool asc, int takeArticleNum)
        {
            ArticleCategoryModel model = new ArticleCategoryModel
            {
                Items = connectedMapper.Map<List<ArticleCategoryModel>>(_repository.GetSeriesArticle(id, asc, takeArticleNum))
            };

            model.Author = model.Items.Select(a => a.Author).FirstOrDefault();
            model.CategoryId = model.Items.Select(a => a.CategoryId).FirstOrDefault();
            model.CategoryTitle = model.Items.Select(a => a.CategoryTitle).FirstOrDefault();
            model.CategorySummary = model.Items.Select(a => a.CategorySummary).FirstOrDefault();

            return model;
        }

        public int GetAuthorCategoryCount(int id)
        {
            return _repository.GetAuthorCategoryCount(id);
        }

        /// <summary>
        /// Get total article count of specified author.
        /// </summary>
        /// <param name="id">Need authorId</param>
        /// <returns>Return specified author article count</returns>
        public int GetAuthorCount(int id)
        {
            return _repository.GetAuthorCount(id);
        }

        /// <summary>
        /// Article author page need data.
        /// </summary>
        /// <param name="id">Need author id</param>
        /// <param name="pageSize">For show page count</param>
        /// <param name="pageIndex">Cruuent page id</param>
        /// <returns>Return articleAuthorModel with info</returns>
        public AritcleAuthorModel GetAuthorArticle(int id, int pageSize, int pageIndex)
        {
            IList<Article> tempArticle = new List<Article>();
            tempArticle = _repository.GetAuthorArticles(id, pageSize, pageIndex);
            AritcleAuthorModel model = new AritcleAuthorModel
            {
                Items = connectedMapper.Map<List<AritcleAuthorModel>>(tempArticle)
            };
            model.Author = model.Items.Select(a => a.Author).FirstOrDefault();
            return model;
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


            _articleEntity = _repository.GetUseSeries(id);
            temp.SeriesId = _articleEntity.UseSeries.Id;
            temp.SeriesTitle = new SeriesRepository(dbContext).Find(temp.SeriesId).ContentOfSeries;

            foreach (var item in _repository.GetNeighbourArticleInfo(id))
            {
                if (temp.LastArticleId == 0)
                {
                    temp.LastArticleId = 1;
                    if (item != null)
                    {
                        temp.LastArticleId = item.Id;
                        temp.LastArticleTitle = item.Title;
                        continue;
                    }
                    continue;
                }
                if (item == null)
                {
                    return temp;
                }
                temp.NextArticleId = item.Id;
                temp.NextArticleTitle = item.Title;
                return temp;
            }
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

            var keywords = new KeywordAndArticleRepository(dbContext).GetKeywords(id.Value);

            if (keywords != null)
            {
                string keyWordOfArticle = string.Empty;
                foreach (var item in keywords)
                {
                    keyWordOfArticle += item.Keyword.Name + " ";
                }
                articleEditModel.Keywords = keyWordOfArticle;
            }

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
