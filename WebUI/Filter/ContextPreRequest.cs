using ProductServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Filter
{
    public class ContextPreRequest : ActionFilterAttribute 
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (!filterContext.IsChildAction)
            {
                new BaceService().SaveChangesForFilter();
            }
            base.OnActionExecuted(filterContext);
        }
    }
}