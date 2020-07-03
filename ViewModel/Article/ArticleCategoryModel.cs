using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Article
{
    public class ArticleCategoryModel
    {

        public int AuthorId { set; get; }

        public string Author { set; get; }

        public int Level { set; get; }



        public int CategoryId { set; get; }
        
        public string CategoryTitle { set; get; }

        public string CategorySummary { set; get; }



        public int Id { set; get; }

        public string Title { set; get; }

        public string Body { set; get; }

        public string Summary { set; get; }

        public DateTime PublishTime { get; set; }
        public int SumOfCategory { set; get; }

        public IList<KeywordModel> ListKeyword { set; get; }

        public IList<ArticleCategoryModel> Items { set; get; }


    }
}
