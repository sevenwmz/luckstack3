using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityMVC
{
    public class Email
    {
        public string Address { set; get; }
        public string Code { set; get; }
        public DateTime? Expire { set; get; }
        public bool IsActive { set; get; }



    }
}
