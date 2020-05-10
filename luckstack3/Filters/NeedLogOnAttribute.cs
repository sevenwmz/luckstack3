using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _17bang.Filters
{
    public class NeedLogOnAttribute : Attribute, IResourceFilter
    {
        ///参考一起帮，使用[NeedLogOn]保证未登录用户无法访问只有登录用户才能访问的页面： 
        ///1.未登录用户强行访问上述页面，自动跳转到登录页面 
        ///2.此时的登录页面显示提示 
        ///3.登录之后，自动跳转到之前欲访问页面

        public NeedLogOnAttribute()
        {

        }
        private string _role;
        public NeedLogOnAttribute(string role)
        {
            _role = role;
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            context.Result = new RedirectToPageResult(Const.PREPAGE);
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {

            HttpContext httpContext = context.HttpContext;
            HttpRequest request = httpContext.Request;

            string prePage = request.Path + request.QueryString;

            string LogOnUser = httpContext.Session.GetString(Const.SESSION_USER);
            if (string.IsNullOrEmpty(LogOnUser))
            {
                context.Result = new RedirectResult($"/Log/On?{Const.PREPAGE}={prePage}&{Const.ROLE}={_role}");
            }//else nothing..

        }
    }
}
