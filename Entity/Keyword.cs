using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Keyword
    {
        public Keyword()
        {

        }

        IList<Article> articles { set; get; }
        public string KeyWord { set; get; }
    }
}
