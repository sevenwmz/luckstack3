using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_Of_EFCore
{
    public class Keywords : BaceEntity
    {
        public string Name { set; get; }
        public IList<Keywords_Of_Article> Of_ThisArticle { set; get; }
        public IList<Keywords_Of_Problem> Of_ThisProblem { set; get; }

    }

}
