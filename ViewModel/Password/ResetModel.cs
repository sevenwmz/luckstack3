using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Password
{
    public class ResetModel
    {
        public string VerifyCode { set; get; }

        [Required(ErrorMessage ="必须要填写哦，不能和旧密码一样" )]
        public string Password { set; get; }

        [Compare(nameof(Password))]
        public string ConfrimPassword { set; get; }

    }
}
