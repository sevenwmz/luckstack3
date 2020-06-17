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
        public void AddDatabase(int articleId, IList<int> keywordsId)
        {
            KeywordsAndArticle temp = new KeywordsAndArticle(); 
            foreach (var item in keywordsId)
            {
                temp.ArticleId = articleId;
                temp.KeywordId = item;
            };
            Context.KeywordsAndArticle.Add(temp);
            Context.SaveChanges();

        }
    }
}
