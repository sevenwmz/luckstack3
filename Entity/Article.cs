using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Article : Content
    {


        #region Constructer
        public Article()
        {

        }
        public Article(string title) : base("article")
        {
            ///确保文章（Article）的标题不能为null值，
            ///也不能为一个或多个空字符组成的字符串，而且如果标题前后有空格，也予以删除
            if (string.IsNullOrWhiteSpace(title))
            {
                return;
            }
            Title = title.Trim();
        }


        #endregion

        #region Field and properties

        public string Series { set; get; }


        public string Ad { set; get; }

        public string ContentOfAd { set; get; }

        public string WebSite { set; get; }

        #endregion

        #region Function


        public override void Publish()
        {
            base.Publish();
            Author.HelpMoney--;
            Console.WriteLine("database");
        }

        internal override int DisAgree(User voter)
        {
            Author.HelpBean--;
            voter.HelpBean++;
            return Author.HelpBean;
        }

        internal override int Agree(User voter)
        {
            Author.HelpBean++;
            voter.HelpBean--;
            return Author.HelpBean;
        }

        public static Article ChangeArticleContent(Article editPublish)
        {
            Article temp = new Article();
            temp.Title = editPublish.Title;
            temp.Summary = editPublish.Summary;
            temp.Reward = editPublish.Reward;
            return temp;
        }

        #endregion

    }
}
