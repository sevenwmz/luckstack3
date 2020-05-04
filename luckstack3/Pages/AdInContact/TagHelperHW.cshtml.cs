using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _17bang
{
    public class TagHelperHWModel : PageModel
    {
        public string Name { set; get; } = "wpz";
        public void OnGet()
        {

        }
    }
}