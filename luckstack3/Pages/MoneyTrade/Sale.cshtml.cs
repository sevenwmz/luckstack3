using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _17bang
{
    public class SaleModel : PageModel
    {
        public User User { set; get; }
        public int SaleCount { set; get; }
        public int TotalSaleMoney { set; get; }
        public string Message { set; get; }
        public void OnGet()
        {

        }
    }
}