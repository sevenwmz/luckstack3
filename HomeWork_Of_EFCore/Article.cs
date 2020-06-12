using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_Of_EFCore
{
    public class Article : BaceContent
    {
        public string AuthorId { set; get; }
        public User Author { set; get; }

        public IList<Keywords_Of_Article> ArticleHave { set; get; }
    }
}
