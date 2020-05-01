using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _17bang
{
    public class NewModelOfPlan : PageModel
    {
        public string Title { set; get; }

        public string Other { set; get; }

        public string Tags { set; get; }

        public int StartTime { set; get; }

        public int EndTime { set; get; }

        public string[] WeekOfDay = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };

        public IList<bool> ChoosDay { set; get; }

        public int Leave { set; get; }

        public IList<SelectListItem> LeaveRestDay { get; } =
         new List<SelectListItem>
         {
                new SelectListItem{Text= "1",Value= "1" },
                new SelectListItem{Text= "2",Value= "2" },
                new SelectListItem{Text= "3",Value= "3" },
                new SelectListItem{Text= "4",Value= "4" },
                new SelectListItem{Text= "5",Value= "5" },
                new SelectListItem{Text= "6",Value= "6" },
         };


        public string Evidence { set; get; }

        public string WebAdress { set; get; }

        public int Helper { set; get; }

        public IList<SelectListItem> HelperTotal { get; } =
         new List<SelectListItem>
         {
                new SelectListItem{Text= "1",Value= "1" },
                new SelectListItem{Text= "2",Value= "2" },
                new SelectListItem{Text= "3",Value= "3" },
                new SelectListItem{Text= "4",Value= "4" },
                new SelectListItem{Text= "5",Value= "5" },
         };

        public string Coin { set; get; }

        public bool Continue { set; get; }


        public void OnGet()
        {
            ChoosDay = new List<bool> { true, true, true, true, true, true, true };
        }

        public void OnPost()
        {

        }
    }
}