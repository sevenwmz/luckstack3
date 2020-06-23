using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class EmailModel
    {
        public string UserName { set; get; }
        public string EmailAddress { set; get; }
        public string Code { set; get; }
        public DateTime? Expire { set; get; }
        public bool IsActive { set; get; }
    }
}
