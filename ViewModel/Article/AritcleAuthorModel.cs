using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Article
{
    public class AritcleAuthorModel
    {
        public int Id { set; get; }

        public string Author { set; get; }

        public int Level { set; get; }

        public int AuthorId { set; get; }

        public string Title { set; get; }

        public string Body { set; get; }

        public string Summary { set; get; }

        public DateTime PublishTime { get; set; }
        public int SumOfAuthor { set; get; }

        public IList<KeywordModel> ListKeyword { set; get; }

        public IList<AritcleAuthorModel> Items { set; get; }
    }
}
