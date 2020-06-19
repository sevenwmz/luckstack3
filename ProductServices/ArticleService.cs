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
            KeywordRepository keywordRepository = new KeywordRepository();
            foreach (var item in keywords)
            {
                int keywordId = 0;
                Keywords temp = keywordRepository.GetByKeyword(item);
                if (temp == null)
                {
                    Keywords tempAdd = new Keywords();
                    tempAdd = tempAdd.AddNewKeyword(item);
                    keywordId = keywordRepository.AddKeywordToDatabase(tempAdd);
                }
                else
                {
                    temp = temp.AddUsed(temp);
                    keywordId = keywordRepository.UpdateKeywordUsed(temp);
                }
                new KeywordAndArticleRepository().AddDatabase(articleId, keywordId);
            }

            ///Minus article author BMoney
            BMoney money = new BMoney();
            BMoneyRepository bMoneyRepository = new BMoneyRepository();
            //inside this function have problem ,because this userId give is 4,forever,just test use.
            money = money.PublicArticleMinusBMoney(bMoneyRepository.GetByAuthorBMoney(article.Author));//lazy to do extension
            bMoneyRepository.AddNewRow(money);

            return articleId;
        }
    }
}
