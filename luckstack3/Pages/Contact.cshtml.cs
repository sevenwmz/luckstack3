using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace luckstack3
{
    public class ContactModel : PageModel
    {

        public int QQ { set; get; }

        public string WeChat { set; get; }

        public int Phone { set; get; }

        public string Other { set; get; }

        public void OnGet()
        {

        }
    }
}