using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Suggest :Content
    {

        #region Constructer

        public Suggest()
        {

        }

        #endregion

        #region filed and properties
        internal int Level { set; get; }//database provide support
        #endregion

        #region Function
        public override void Release()
        {
            base.Release();
            Comment = int.Parse(Console.ReadLine());
            Level = int.Parse(Console.ReadLine());//console.readline is database.
        }
        #endregion

    }
}
