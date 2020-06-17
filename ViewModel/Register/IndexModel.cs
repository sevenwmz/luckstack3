using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class RegisterModel
    {
        #region Register preproty

        [Required(ErrorMessage = "* 邀请人不能为空")]
        public string Inviter { set; get; }

        [Display(Name = "邀请码：（* 必填）")]
        [Required(ErrorMessage = "* 邀请码不能为空")]
        public int InviterNumber { set; get; }

        [Required]
        [Display(Name = "用户名：（* 必填）")]
        public string UserName { set; get; }

        [Required]
        [Display(Name = "密码：（* 必填） ")]
        public string Password { set; get; }

        [Required]
        [Display(Name = "验证密码：（* 必填）")]
        [Compare(nameof(Password))]
        public string PasswordAgain { set; get; }

        //[Required]
        [Display(Name = "验证码：（* 必填） ")]
        public string Captcha { set; get; }
        public int CookieId { set; get; }

        //private UserRepository _userRepository;
        #endregion
    }
}
