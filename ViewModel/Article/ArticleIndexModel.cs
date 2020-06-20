using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityMVC;

namespace ViewModel.Article
{
    public class ArticleIndexModel
    {
        public int SumOfArticle { set; get; }
        public string Author { set; get; }
        public int Level { set; get; }
        public int Id { set; get; }
        public IList<ArticleItemsModel> Items { set; get; }
        public IList<KeywordsModel> ListKeywords { set; get; }

    }
}
