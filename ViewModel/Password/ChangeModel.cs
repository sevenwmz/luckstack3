using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Password
{
    public class ChangeModel
    {
        public string OldPwd { set; get; }
        public string NewPwd { set; get; }
        public string ConfrimPwd { set; get; }
    }
}
