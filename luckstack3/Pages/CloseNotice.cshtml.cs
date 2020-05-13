using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _17bang
{
    public class CloseNoticeModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Id { set; get; }
        public IActionResult OnGet()
        {
            //NoticeModel.ShowNotice = false;
            Response.Cookies.Append(Const.NOTICE_HASREAD,Request.Cookies[Const.NOTICE_HASREAD]+","+Id.ToString(),
                new Microsoft.AspNetCore.Http.CookieOptions { Expires = DateTime.Now.AddDays(30)});

            string prePage =  Request.Query[Const.PREPAGE];

            if (string.IsNullOrEmpty(prePage))
            {
                return Redirect("/");
            }
            return Redirect(prePage);
        }
    }
}