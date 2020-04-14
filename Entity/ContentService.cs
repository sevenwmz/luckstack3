using LanguageExt;
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

        [HelpMoneyChanged(2, AttributeTargets.Method)]
        public void Publish(Content content)
        {
            try
            {
                content.Publish();
            }
            catch (ArgumentNullException e)
            {
                throw new InnerException(e.InnerException);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("求助的Reward为负数（-XX）是无效的");
            }
        }
        #endregion



    }
}
