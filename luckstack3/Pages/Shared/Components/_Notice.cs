using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _17bang
{
    public class NoticeModel : ViewComponent
    {
        public NoticeModel Nothing;
        public static bool ShowNotice;

        public IViewComponentResult Invoke()
        {
            string hasCookie = HttpContext.Request.Cookies[Const.COOKIE_USER];
            ShowNotice = string.IsNullOrEmpty(hasCookie) ? ShowNotice = true : ShowNotice;

            return View();
        }
    }
}