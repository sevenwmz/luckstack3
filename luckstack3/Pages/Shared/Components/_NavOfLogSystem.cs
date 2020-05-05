using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _17bang
{
    public class _NavOfLogSystemModel : ViewComponent
    {
        public _NavOfLogSystemModel Nothing;


        public int Id { set; get; }

        public IViewComponentResult Invoke()
        {
            

            return View("/Pages/Shared/_NavOfLogSystem.cshtml", Nothing);
        }
    }
}