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
    public class RegisterModel : PageModel
    {
        [Required(ErrorMessage ="* 邀请人不能为空")]
        public string Inviter { set; get; }

        [Required(ErrorMessage = "* 邀请码不能为空")]
        public int? InviterNumber { set; get; }

        public User Regester { get; set; }

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