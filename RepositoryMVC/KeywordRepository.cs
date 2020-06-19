using EntityMVC;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryMVC
{
    public class KeywordRepository : BaceRepository<Keywords>
    {
        public KeywordRepository(DbContext context) : base(context)
        {

        }

        public int AddKeywordToDatabase(Keywords keywords)
        {
            entities.Add(keywords);
            return keywords.Id;
        }

        public Keywords GetByKeyword(Keywords keyword)
        {
            return entities.Where(k => k.Name == keyword.Name).FirstOrDefault();
        }

        public int UpdateKeywordUsed(Keywords item)
        {
            entities.Attach(item);
            return item.Id;
        }
    }
}
