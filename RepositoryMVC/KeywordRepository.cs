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

        public int AddKeywordToDatabase(Keywords keywords)
        {
            Context.Keywords.Add(keywords);
            Context.SaveChanges();
            return keywords.Id;
        }
    }
}
