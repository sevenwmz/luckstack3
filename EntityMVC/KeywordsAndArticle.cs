using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityMVC
{
    public class KeywordsAndArticle
    {
        public int ArticleId { set; get; }
        public Article Article { set; get; }
        public int KeywordId { set; get; }
        public Keywords Keyword { set; get; }
    }
}
