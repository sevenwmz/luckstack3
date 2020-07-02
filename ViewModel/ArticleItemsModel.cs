using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ArticleItemsModel
    {
        public int Id { set; get; }

        public string Author { set; get; }
        
        public int Level { set; get; }
        
        public int AuthorId { set; get; }
        
        public string Title { set; get; }

        public string Body { set; get; }

        public string Summary { set; get; }

        public DateTime PublishTime { get; set; }
        public IList<KeywordModel> ListKeyword { set; get; }

    }
}
