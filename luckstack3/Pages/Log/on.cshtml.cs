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
    public class signinModel : PageModel
    {

        public User UserName;

        [DataType(DataType.Password)]
        public User UserPwd;
        public string Captcha { set; get; }

        public void OnGet()
        {

        }
    }
}