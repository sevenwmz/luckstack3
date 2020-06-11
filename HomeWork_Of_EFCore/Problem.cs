using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_Of_EFCore
{
    public class Problem : BaceContent
    {
        public int Reward { set; get; }

        public string AuthorId { set; get; }
        public User Author { set; get; }
        public int? HaveKindId { set; get; }
        public Kind HaveKind { set; get; }

        public ProblemStatus Statu { set; get; }
        public IList<Keywords_Of_Problem> ProblemHave { set; get; }
    }
}
