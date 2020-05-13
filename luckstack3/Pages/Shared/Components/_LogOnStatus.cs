using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _17bang
{
    public class _LogOnStatus : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            
            return View( );
        }
    }
}