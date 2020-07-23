using ProductServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class LogOnController : BaseController
    {
        // GET: _LogOn
        [ChildActionOnly]
        public PartialViewResult _LogOn()
        {
            return PartialView(new LogOnService().GetCurrentUserInfo());
        }




    }
}