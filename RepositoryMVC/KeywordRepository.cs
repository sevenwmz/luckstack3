using EntityMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryMVC
{
    public class KeywordRepository : BaceRepository
    {

        public IList<int> AddKeywordToDatabase(IList<Keywords> keywords)
        {
            IList<int> tempKeywordId = new List<int>();
            foreach (var item in keywords)
            {
                Context.Keywords.Add(item);
                tempKeywordId.Add(item.Id);
            }
            Context.SaveChanges();
            return tempKeywordId;
        }
    }
}
