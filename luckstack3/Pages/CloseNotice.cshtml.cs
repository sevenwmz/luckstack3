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

        public IActionResult OnGet()
        {
            NoticeModel.ShowNotice = false;
            Response.Cookies.Append(Const.COOKIE_USER, Const.COOKIE_VALUE);

            string prePage =  Request.Query[Const.PREPAGE];

            if (string.IsNullOrEmpty(prePage))
            {
                return Redirect("/");
            }
            return Redirect(prePage);
        }
    }
}