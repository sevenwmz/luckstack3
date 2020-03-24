using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class ContentService
    {
        #region Constructer
        public ContentService()
        {

        }

        public ContentService(string name)
        {
            _name = name;

        }

        #endregion

        #region Filed and propertise
        private string _name { set; get; }
        #endregion

        #region Function


        public  void Publish(Content content)
        {
            content.Release();//变化的
            Console.WriteLine("database");//不变的
        }
        #endregion
    }
}
