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

        public IList<ArticleItemsModel> Items { set; get; }

    }
}
