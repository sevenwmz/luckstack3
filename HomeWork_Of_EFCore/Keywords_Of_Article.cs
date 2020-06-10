using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_Of_EFCore
{
    public class Keywords_Of_Article
    {
        public int ArticleId { set; get; }
        public Article Article { set; get; }
        public int KeywordId { set; get; }
        public Keywords Keyword { set; get; }
    }
}
