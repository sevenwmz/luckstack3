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

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            if (!filterContext.IsChildAction)
            {
                BaceService service = new BaceService();
                if (filterContext.Exception == null)
                {
                    service.Commit();
                }
                else
                {
                    service.RollBack();
                }
                //service.ClearContext();
            }
            base.OnResultExecuted(filterContext);
        }
    }
}