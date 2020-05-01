using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace luckstack3
{
    [BindProperties]
    public class SigninModel : PageModel
    {

        public User UserName { set; get; }

        public bool RemenberMe { set; get; }

        public string Captcha { set; get; }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                return;
            }
        }
    }
}