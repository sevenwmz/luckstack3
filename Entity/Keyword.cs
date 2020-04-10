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
        public string Name { get; set; }
        public IList<Article> articles { set; get; }
    }
}
