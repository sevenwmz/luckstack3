using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using _17bang;
using _17bang.Repository;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace luckstack3
{
    [BindProperties]
    public class LogOnModel : PageModel
    {
        #region Fileds 
        [Required(ErrorMessage = "* 用户名不能为空")]
        [StringLength(6, MinimumLength = 4, ErrorMessage = "* 最大长度不能超过6")]
        [Display(Name = "* 用户名")]
        public string Name { set; get; }

        [DataType(DataType.Password)]
        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(/*AllowEmptyStrings = true, */ErrorMessage = "* 密码不能为空")]
        public string Password { set; get; }

        private UserRepository _repository { set; get; }
        public LogOnModel()
        {
            _repository = new UserRepository();
        }

        public bool RemenberMe { set; get; }

        public string Captcha { set; get; }

        //Best ideal , I can't delete it  /xyx
        public static bool IsLogIn { set; get; }
        #endregion

        public void OnGet()
        {

        }

        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //User user = _repository.GetByName(Name);

            #region Main function of check userInfo exists
            LogOnModel logOn = new LogOnModel
            {
                Name = this.Name,
                Password = this.Password
            };
            if (!_repository.VerifyLogIn(logOn))
            {
                ModelState.AddModelError(nameof(Password), "用户名或密码不正确");
                return Page();
            }

            #endregion



            //Response.Cookies.Append(Name, (++_cookie).ToString());
            HttpContext.Session.SetString(Const.SESSION_USER, Const.SESSION_VALUE);
            if (RemenberMe)
            {
                Response.Cookies.Append(Const.COOKIE_USER, Const.COOKIE_VALUE);
                new CookieOptions { Expires = DateTime.Now.AddDays(90) };
            }

            //登陆传值
            IsLogIn = true;
            return Redirect(Request.Query[Const.PREPAGE]);

        }
    }
}