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
            base.Agree(voter);
            base.Disagree(voter);
            User Author = new User("", "");
            Author.HelpMoney--;
            Console.WriteLine("database");
        }

        #endregion

    }
}
