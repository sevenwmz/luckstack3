using EntityMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryMVC
{
    public class KeywordAndArticleRepository : BaceRepository
    {
        public void AddDatabase(int articleId, int keywordId)
        {
            Context.KeywordsAndArticle.Add(new KeywordsAndArticle { ArticleId = articleId, KeywordId = keywordId });
            Context.SaveChanges();
        }
    }
}
