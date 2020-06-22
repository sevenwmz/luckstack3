using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityMVC
{
    public class KeywordsAndProblem : BaceEntity
    {
        public int ProblemId { set; get; }
        public Problem Problem { set; get; }
        public int KeywordId { set; get; }
        public Keywords Keyword{ set; get; }

    }
}
