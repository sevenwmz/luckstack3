using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_Of_EFCore
{
    public class Keywords_Of_Problem
    {
        public int ProblemId { set; get; }
        public Problem Problem { set; get; }
        public int KeywordId { set; get; }
        public Keywords Keyword { set; get; }
    }
}
