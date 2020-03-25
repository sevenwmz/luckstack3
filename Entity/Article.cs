using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Article : Content
    {
        

        #region Constructer

        public Article() : base("article")
        {

        }
        #endregion

        #region Field and properties

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
