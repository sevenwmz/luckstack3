using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Article :Content 
    {

        #region Constructer

        public Article(): base("article")
        {

        }
        #endregion

        #region Field and properties
        

        #endregion

        #region Function
        public override void Release()
        {
            base.Release();
            _helpMoney -= 1;
        }
        
        #endregion

    }
}
