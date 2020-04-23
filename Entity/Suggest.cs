using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Suggest : Content
    {

        #region Constructer

        public Suggest() : base("Suggest")
        {

        }

        #endregion
        public string News { set; get; }
        #region Function
        public void Publish(User Author)
        {
            base.Publish();
            Author.HelpBean++;
            Console.WriteLine("database");
        }
        //一起帮里的求助总结、文章和意见建议，以及他们的评论，都有一个点赞（Agree）/
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
