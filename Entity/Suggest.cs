using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Suggest :Content
    {

        #region Constructer

        public Suggest():base("Suggest")
        {

        }

        #endregion

        #region filed and properties
        internal int Level { set; get; }//database provide support
        #endregion

        #region Function
        public void Publish(User Author)
        {
            base.Publish();
            Author.HelpBean++;
            Console.WriteLine("database");
        }
        #endregion

    }
}
