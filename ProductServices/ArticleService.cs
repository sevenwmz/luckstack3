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

        public int Add(ArticleNewModel model)
        {
            Article _articleEntity = new Article();

            Article article = connectedMapper.Map<Article>(model);
            if (string.IsNullOrEmpty(model.Summary))
            {
                article.Summary = _articleEntity.GetSumarry(model.Body);
            }
            _articleEntity.PublishArticle(article);

            //Fake user --pretend take from Seesion
            article.Author = new User { Id = 4 };

            //Get and save series with AD to article foregin key.
            article.UseSeries = new SeriesRepository().GetSeries(model.ChoosSeries);
            article.UseAd = new ADRepository().GetAD(model.ChoosAd);

            int articleId = new ArticleRepository().AddArticleToDatabase(article);

            //Save keywords and into n:n table.
            IList<Keywords> keywords = new Keywords().GetKeywordList(model.Keywords);
            foreach (var item in keywords)
            {
                int keywordId = new KeywordRepository().AddKeywordToDatabase(item);
                new KeywordAndArticleRepository().AddDatabase(articleId, keywordId);
            }

            return articleId;
        }
    }
}
