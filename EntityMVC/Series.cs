using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityMVC
{
    public class Series : BaceEntity
    {
        public string Summary { set; get; }
        public string ContentOfSeries { set; get; }
        public int? OwnerId { set; get; }
        public User Owner { set; get; }
        public IList<Article> ArticleUse { set; get; }

    }
}
