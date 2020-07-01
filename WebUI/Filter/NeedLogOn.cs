using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Filter
{
    public class NeedLogOnAttribute : ActionFilterAttribute
    {

        private string _role;
        public NeedLogOnAttribute(string role)
        {
            _role = role;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            HttpContextBase httpContext = filterContext.HttpContext;
            HttpRequestBase request = httpContext.Request;

            string prePage = request.Path + request.QueryString;

            string LogOnUser = httpContext.Request.Cookies.Get(Const.COOKIE_NAME).ToString();
            if (string.IsNullOrEmpty(LogOnUser))
            {
                filterContext.Result = new RedirectResult($"/Log/On?{Const.PREPAGE}={prePage}&{Const.ROLE}={_role}");
            }//else nothing..


            base.OnActionExecuting(filterContext);
        }

    }
}