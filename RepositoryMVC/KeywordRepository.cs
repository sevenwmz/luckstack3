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

        public Keywords GetByKeyword(Keywords keyword)
        {
            return Context.Keywords.Where(k => k.Name == keyword.Name).FirstOrDefault();
        }

        public int UpdateKeywordUsed(Keywords item)
        {
            Context.Keywords.Attach(item);
            Context.SaveChanges();
            return item.Id;
        }
    }
}
