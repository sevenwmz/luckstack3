using EntityMVC;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryMVC
{
    public class ArticleRepository  : BaceRepository<Article>
    {

        public ArticleRepository(DbContext context) : base(context)
        {

        }
        public int AddArticleToDatabase(Article article)
        {
            entities.Add(article);
            return article.Id;
        }
    }
}
