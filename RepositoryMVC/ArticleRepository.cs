using EntityMVC;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryMVC
{
    public class ArticleRepository : BaceRepository<Article>
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

        public Article Find(int articleId)
        {
            return entities
                .Include(p => p.OwnKeyword.Select(o => o.Keyword))
                .Where(a => a.Id == articleId).FirstOrDefault();
        }

        public IList<Article> GetArticles(int pageSize, int pageIndex)
        {
            return entities.Include(e => e.Author)
                .Include(k => k.OwnKeyword.Select(o => o.Keyword))
                .OrderByDescending(a => a.PublishTime)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public IList<Article> GetSeriesArticle(int id, bool Asc,int takeArticleNum)
        {
            IList<Article> temp = new List<Article>();
            temp = GetSeriesArticle(id,Asc);
            if (takeArticleNum == 1000)
            {
                return temp.Take(1000).ToList();
            }
            if(takeArticleNum == 50)
            {
                return temp.Take(50).ToList();
            }
            return temp.Take(10).ToList();
        }

        public int GetAuthorCategoryCount(int id)
        {
            return entities.Where(a => a.UseSeries.Id == id).Count();
        }

        public IList<Article> GetSeriesArticle(int id, bool Asc)
        {
            if (Asc)
            {
                return entities.Include(e => e.Author)
                .Include(s => s.UseSeries)
                .Include(k => k.OwnKeyword.Select(o => o.Keyword))
                .OrderBy(a => a.PublishTime)
                .Where(a => a.UseSeries.Id == id)
                .ToList();
            }
            return entities.Include(e => e.Author)
                .Include(s => s.UseSeries)
                .Include(k => k.OwnKeyword.Select(o => o.Keyword))
                .OrderByDescending(a => a.PublishTime)
                .Where(a => a.UseSeries.Id == id)
                .ToList();
        }




        public IList<Article> GetAuthorArticles(int authorId, int pageSize, int pageIndex)
        {
            return entities.Include(e => e.Author)
                .Include(k => k.OwnKeyword.Select(o => o.Keyword))
                .OrderByDescending(a => a.PublishTime)
                .Where(a => a.Author.Id == authorId)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }


        public int ArticlesCount()
        {
            return entities.Count();
        }

        public int GetAuthorCount(int id)
        {
            return entities.Where(a => a.Author.Id == id).Count();
        }

        public Article GetEditArticle(int? id)
        {
            return entities
                .Include(a => a.Author)
                .Include(a => a.OwnKeyword)
                .Include(a => a.UseSeries)
                .Include(a => a.UseAd)
                .Where(a => a.Id == id).FirstOrDefault();
        }

    }
}
