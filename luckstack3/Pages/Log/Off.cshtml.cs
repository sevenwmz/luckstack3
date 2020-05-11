using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _17bang.Repository;
using Entity;
using luckstack3;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _17bang
{
    public class OffModel : PageModel
    {
        
        public IActionResult OnGet()
        {
            //删除登陆状态
            LogOnModel.IsLogIn = false;
            Response.Cookies.Delete(Const.COOKIE_USER);

            return Redirect(Request.Query[Const.PREPAGE]);
        }
    }
}