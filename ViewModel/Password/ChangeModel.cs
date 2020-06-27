using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Password
{
    public class ChangeModel
    {
        [Required(ErrorMessage = "旧密码一定要写呦")]
        public string OldPwd { set; get; }

        [Required(ErrorMessage = "新密码也一定要写呦")]
        [Compare(nameof(ConfrimPwd))]
        public string NewPwd { set; get; }

        [Required(ErrorMessage = "不要把我忘记")]
        public string ConfrimPwd { set; get; }
    }
}
