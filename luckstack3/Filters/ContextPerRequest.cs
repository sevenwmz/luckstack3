using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _17bang.Filters
{
    public class ContextPerRequest : IPageFilter
    {
        public static bool ShowNotice { set; get; }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
            //context.HttpContext.
            //throw new NotImplementedException();
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            //string hasCookie = context.HttpContext.Request.Query[Const.COOKIE_USER];
            //if (string.IsNullOrEmpty(hasCookie))
            //{
            //    ShowNotice = true;
            //}//else nothing.


        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
            //throw new NotImplementedException();
        }
    }
}
