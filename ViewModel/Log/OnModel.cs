using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Log
{
    public class OnModel 
    {
        public int Id { set; get; }
        [Required(ErrorMessage = "* 用户名不能为空")]
        [StringLength(6, MinimumLength = 4, ErrorMessage = "* 最大长度不能超过6")]
        [Display(Name = "* 用户名")]
        public string LogInName { set; get; }

        [DataType(DataType.Password)]
        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(/*AllowEmptyStrings = true, */ErrorMessage = "* 密码不能为空")]
        public string Password { set; get; }
        public bool RemenberMe { set; get; }
        [Required(ErrorMessage = "* 验证码不能为空/填错啦")]
        public string Captcha { set; get; }
    }
}
