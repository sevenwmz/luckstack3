using EntityMVC;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryMVC
{
    public class KeywordAndProblemRepository : BaceRepository<KeywordsAndProblem>
    {
        public KeywordAndProblemRepository(DbContext context) : base(context)
        {

        }

        public IList<KeywordsAndProblem> GetKeywords(int id)
        {
            return entities.Include(k => k.Keyword).Where(k => k.ProblemId == id).ToList();
        }

        public void SaveToMiddle(int id, int keywordId)
        {
            entities.Add(new KeywordsAndProblem { ProblemId = id , KeywordId = keywordId });
            context.SaveChanges();
        }
    }
}
