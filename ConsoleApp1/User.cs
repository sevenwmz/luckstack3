using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_Of_EF6
{
    public class User : BaseEntity
    {
        public string Name { set; get; }
        public int FailedTry { set; get; }
    }
}
