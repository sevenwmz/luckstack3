using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using _17bang;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace luckstack3
{
    [BindProperties]
    public class RegisterModel : PageModel
    {
        [Required(ErrorMessage ="* 邀请人不能为空")]
        public string Inviter { set; get; }

        [Required(ErrorMessage = "* 邀请码不能为空")]
        public int? InviterNumber { set; get; }

        public User Regester { get; set; }

        public string Captcha { set; get; }

        public int CookieId { set; get; }
        public void OnGet()
        {
            ViewData["preRegister"] = Request.Query[Const.PREPAGE];
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            HttpContext.Session.SetString(Const.COOKIE_USER,Const.COOKIE_VALUE);
            Response.Cookies.Append(Const.COOKIE_USER, Const.COOKIE_VALUE);
            return Redirect(Request.Query[Const.PREPAGE]);
        }
    }
}