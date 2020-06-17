using EntityMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryMVC
{
    public class ArticleRepository
    {
        private SqlContext _context;
        public int AddArticleToDatabase(Article article)
        {
            _context.Articles.Add(article);
            _context.SaveChanges();
            return article.Id;
        }
    }
}
