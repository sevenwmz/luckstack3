using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Password
{
    public class ForgetModel
    {
        public string EmailAddress { set; get; }
        public string UserName { set; get; }
        public string Captcha { set; get; }

    }
}
