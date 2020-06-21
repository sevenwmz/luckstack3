using EntityMVC;
using RepositoryMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices
{
    public class KeywordAndArticleService : BaceService
    {
        private KeywordAndArticleRepository _repo;
        private KeywordsAndArticle _keywordsAndArticle;
        public KeywordAndArticleService()
        {
            _repo = new KeywordAndArticleRepository(dbContext);
            _keywordsAndArticle = new KeywordsAndArticle();
        }

    }
}
