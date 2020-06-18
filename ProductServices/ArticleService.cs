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
            Article _articleEntity = new Article();
            ArticleRepository _articleRepository = new ArticleRepository();
            KeywordRepository _keywordRepository = new KeywordRepository();
            KeywordAndArticleRepository _keywordAndArticleRepository = new KeywordAndArticleRepository();



            Article article = connectedMapper.Map<Article>(model);
            if (string.IsNullOrEmpty(model.Summary))
            {
                article.Summary = _articleEntity.GetSumarry(model.Body);
            }
            _articleEntity.PublishArticle(article);
            int articleId = _articleRepository.AddArticleToDatabase(article);

            IList<Keywords> keywords = new Keywords().GetKeywordList(model.Keywords);
            IList<int> keywordsId = _keywordRepository.AddKeywordToDatabase(keywords);
            _keywordAndArticleRepository.AddDatabase(articleId, keywordsId);

            return articleId;
        }
    }
}
