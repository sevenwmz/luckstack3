using EntityMVC;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryMVC
{
    public class KeywordAndArticleRepository : BaceRepository<KeywordsAndArticle>
    {
        public KeywordAndArticleRepository(DbContext context) : base(context)
        {

        }
        public void AddDatabase(int articleId, int keywordId)
        {
            entities.Add(new KeywordsAndArticle { ArticleId = articleId, KeywordId = keywordId });
            context.SaveChanges();
        }

        public IList<KeywordsAndArticle> GetKeywords(int id)
        {
            return entities
                .Include(k => k.Keyword)
                .Where(k => k.ArticleId == id).ToList();
        }

        public void DeleteOldRelation(int id)
        {
            entities.Where(ka => ka.ArticleId == id);
        }
    }
}
