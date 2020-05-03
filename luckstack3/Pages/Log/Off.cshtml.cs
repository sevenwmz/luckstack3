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
    [BindProperties]
    public class OffModel : PageModel
    {
        /// <summary>
        /// 这里本意是获得当前的cookie用户，结果想不出来。
        /// </summary>
        public User Name;


        public void OnGet()
        {

        }
        public ActionResult OnPost()
        {

            //if (Name != null)
            //{
            //    Response.Cookies.Delete(Name.ToString());
            //}

            //log/on我是用户名wpzwpz，Pwd 1234
            Response.Cookies.Delete("wpzwpz");

            return RedirectToPage("/Index");
        }
    }
}