using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityMVC
{
    public class Series : BaceEntity
    {
        public string ContentOfSeries { set; get; }
        public IList<Article> ArticleUse { set; get; }
    }
}
