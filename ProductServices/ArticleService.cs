using EntityMVC;
using RepositoryMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ViewModel;

namespace ProductServices
{
    public class ArticleService : BaceService
    {
        private Article _articleEntity = new Article();
        private ArticleRepository _articleRepository = new ArticleRepository();
        private KeywordRepository _keywordRepository = new KeywordRepository();
        private KeywordAndArticleRepository _keywordAndArticleRepository = new KeywordAndArticleRepository();

        public IList<SelectListItem> GetDropDownList<T>(IList<T> ts)
        {
            List<SelectListItem> dropDownList = new List<SelectListItem>();

            for (int i = 0; i < ts.Count; i++)
            {
                dropDownList.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }
            return dropDownList;
        }

        public int Add(ArticleNewModel model)
        {
            Article article = connectedMapper.Map<Article>(model);
            article.Summary = _articleEntity.GetSumarry(model.Body);
            int articleId = _articleRepository.AddArticleToDatabase(article);

            IList<Keywords> keywords = new Keywords().GetKeywordList(model.Keywords);
            IList<int> keywordsId = _keywordRepository.AddKeywordToDatabase(keywords);
            _keywordAndArticleRepository.AddDatabase(articleId, keywordsId);

            return articleId;
        }
    }
}
