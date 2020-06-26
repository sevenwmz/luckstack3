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
            context.SaveChanges();
            return article.Id;
        }

        public int Find(string title)
        {
            return entities.Where(a => a.Title == title).FirstOrDefault().Id;
        }

        public Article Find(int articleId)
        {
            return entities
                .Include(p=>p.OwnKeyword.Select(o=>o.Keyword))
                .Where(a => a.Id == articleId).FirstOrDefault();
        }

        public IList<Article> GetArticles(int pageSize, int pageIndex)
        {
            return entities.Include(e=>e.Author)
                .Include(k=>k.OwnKeyword.Select(o=>o.Keyword))
                .OrderByDescending(a => a.PublishTime)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public int ArticlesCount()
        {
            return entities.Count();
        }

        public Article GetEditArticle(int? id)
        {
            return entities
                .Include(a => a.Author)
                .Include(a=>a.OwnKeyword)
                .Include(a=>a.UseSeries)
                .Include(a=>a.UseAd)
                .Where(a => a.Id == id).FirstOrDefault();
        }

    }
}
