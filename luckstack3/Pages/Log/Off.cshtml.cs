using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _17bang
{
    [BindProperties]
    public class OffModel : PageModel
    {
        public User Name { set; get; }

        public void OnGet()
        {

        }
        public ActionResult OnPost()
        {
            if (Name != null)
            {
                Response.Cookies.Delete("wpzwpz");
            }

            return RedirectToPage("/Index");
        }
    }
}