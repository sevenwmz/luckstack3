using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _17bang.Repository;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _17bang
{
    public class OffModel : PageModel
    {
        public IActionResult OnGet()
        {
            Response.Cookies.Delete(Const.USER);

            return Redirect(Request.Query[Const.PREPAGE]);
        }
    }
}