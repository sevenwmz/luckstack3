using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Article : Content
    {


        #region Constructer
        
        public Article(string title) : base("article")
        {
            ///确保文章（Article）的标题不能为null值，
            ///也不能为一个或多个空字符组成的字符串，而且如果标题前后有空格，也予以删除
            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Article的标题不能为空或空字符组成的字符串");
                return;
            }
            _title = title.Trim();
        }
        #endregion

        #region Field and properties
        private string _title;
        private User voter;
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

        #endregion

    }
}
