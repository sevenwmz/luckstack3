using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityMVC
{
    public class AD : BaceEntity
    {
        public string ContentOfAd { set; get; }
        public string WebSite { set; get; }
        public IList<Article> ArticleUse { set; get; }
    }
}
