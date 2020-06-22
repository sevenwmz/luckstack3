using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityMVC
{
    public class Problem : BaceEntity
    {
        public string Title { set; get; }
        public string Body { set; get; }
        public bool NeedRemoteHelp { set; get; }
        public User HelpFrom { set; get; }
        public DateTime PublishTime { set; get; }
        public User Author { set; get; }
        public IList<KeywordsAndProblem> OwnKeyword { set; get; }

    }
}
