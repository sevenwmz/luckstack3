using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace luckstack3
{
    public class ForgetModel : PageModel
    {

        public string Email { set; get; }

        public User UserName;
        public string Captcha { set; get; }

        public void OnGet()
        {

        }
    }
}