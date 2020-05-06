using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _17bang.Filters;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _17bang
{
    [NeedLogOn]
    [BindProperties]
    public class NewModelOfPlan : PageModel
    {
        public Plan NewPlan { set; get; }

        public string[] WeekOfDay = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };

        public IList<bool> ChoosDay { set; get; }


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

        public IList<SelectListItem> HelperTotal { get; } =
         new List<SelectListItem>
         {
                new SelectListItem{Text= "1",Value= "1" },
                new SelectListItem{Text= "2",Value= "2" },
                new SelectListItem{Text= "3",Value= "3" },
                new SelectListItem{Text= "4",Value= "4" },
                new SelectListItem{Text= "5",Value= "5" },
         };

 

        public void OnGet()
        {
            ChoosDay = new List<bool> { true, true, true, true, true, true, true };
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