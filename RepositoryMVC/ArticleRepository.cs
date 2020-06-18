using EntityMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryMVC
{
    public class ArticleRepository  : BaceRepository
    {
        public int AddArticleToDatabase(Article article)
        {
            Context.Articles.Add(article);
            Context.SaveChanges();
            return article.Id;
        }
    }
}
