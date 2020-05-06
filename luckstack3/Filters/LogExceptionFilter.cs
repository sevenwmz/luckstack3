using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _17bang.Filters
{
    public class LogExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            //throw new NotImplementedException();
        }
    }
}
