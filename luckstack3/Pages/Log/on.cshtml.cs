using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class SigninModel : PageModel
    {


        [Required(ErrorMessage = "* 用户名不能为空")]
        [StringLength(6, MinimumLength = 4, ErrorMessage = "* 最大长度不能超过6")]
        [Display(Name = "* 用户名")]
        public string Name { set; get; }

        [DataType(DataType.Password)]
        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(/*AllowEmptyStrings = true, */ErrorMessage = "* 密码不能为空")]
        public string Password { set; get; }

        private UserRepository _repository { set; get; }
        public SigninModel()
        {
            _repository = new UserRepository();
        }

        public bool RemenberMe { set; get; }

        public string Captcha { set; get; }
        private int _cookie { set; get; }

        private const string ModelError = "ModelError";

        public void OnGet()
        {

        }

        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            User user = _repository.GetByName(Name);



            if (user == null)
            {
                ModelState.AddModelError(nameof(Name), "用户名不存在");

                return Page();
            }
            if (user.Password != Password)
            {
                ModelState.AddModelError(nameof(Password), "用户名或密码不正确");
                return Page();
            }

            Response.Cookies.Append(Name, (++_cookie).ToString());
            HttpContext.Session.SetString(Name, (++_cookie).ToString());
            if (RemenberMe == true)
            {
                Response.Cookies.Append(Name, (++_cookie).ToString(),
                        new CookieOptions { Expires = DateTime.Now.AddDays(90), });
            }
            if (Request.Query[Const.PREPAGE] == "/Register")
            {
                string prePage = Convert.ToString(ViewData["preRegister"]);
                return Redirect(Request.Query[prePage]);
            }

            return Redirect(Request.Query[Const.PREPAGE]);

        }
    }
}