using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityMVC
{
    public class Keywords : BaceEntity
    {
        public string Name { set; get; }
        public int Used { set; get; }

        public int NormalLevelId { set; get; }
        public Keywords NormalLevel { set; get; }
        public int SecendLevelId { set; get; }
        public Keywords SecendLevel { set; get; }
        public int FristLevelId { set; get; }
        public Keywords FirstLevel { set; get; }

        public IList<KeywordsAndArticle> UseArticle { set; get; }

        public IList<Keywords> GetKeywordList(string keywords)
        {
            throw new NotImplementedException();
        }
    }
}
