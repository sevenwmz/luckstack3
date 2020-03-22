using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Article :Content 
    {

        #region Constructer

        public Article()// I forget how to give parameter....ignore error.
        {

        }
        #endregion

        #region Field and properties



        #endregion

        #region Function
        public override void Release()
        {
            base.Release();
            Comment = int.Parse(Console.ReadLine());
        }
        #endregion

    }
}
