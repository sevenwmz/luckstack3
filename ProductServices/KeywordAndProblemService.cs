using EntityMVC;
using RepositoryMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices
{
    public class KeywordAndProblemService : BaceService
    {
        internal void SaveMiddleTale(int id, string needSubKeyword)
        {
            IList<Keywords> keywords = new Keywords().GetKeywordList(needSubKeyword);
            foreach (var item in keywords)
            {
                new KeywordAndProblemRepository(dbContext).SaveToMiddle(id, new KeywordRepository(dbContext).Find(item.Name));
            }

        }
    }
}
