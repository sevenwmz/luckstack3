using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_Of_EFCore
{
    public class Kind : BaceEntity
    {
        public string Name { set; get; }
        public IList<Problem> ThisProblem { set; get; }
    }
}
