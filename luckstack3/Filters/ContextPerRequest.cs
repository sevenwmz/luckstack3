using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _17bang.Filters
{
    public class ContextPerRequest : IPageFilter
    {
        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
            //context.HttpContext.
            //throw new NotImplementedException();
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            //throw new NotImplementedException();
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
            //throw new NotImplementedException();
        }
    }
}
