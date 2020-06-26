using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Article
{
    public class ArticleSingle
    {
        public int Id { set; get; }
        public string Author { set; get; }

        public string Title { set; get; }

        public string Body { set; get; }

        public DateTime PublishTime { get; set; }

        public string ChoosSeries { set; get; }

        public IList<KeywordModel> Keywords { set; get; }
    }
}
