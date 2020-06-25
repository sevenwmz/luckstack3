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
            context.SaveChanges();
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

        public IList<Keywords> GetLevelKeywords(bool fristKeyword)
        {
            if (fristKeyword)
            {
                return entities.Where(k => k.LevelId == 1).ToList();
            }
            return entities.Where(k => k.LevelId == 2).ToList(); ;
        }

        public int Find(string name)
        {
            return entities.Where(k => k.Name == name).FirstOrDefault().Id;
        }

        public Keywords FindKeyword(string keywordName)
        {
            return entities.Where(k => k.Name == keywordName).FirstOrDefault();
        }


    }
}
