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
        }
    }
}
