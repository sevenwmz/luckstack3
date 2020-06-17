using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers.Log
{
    public class OffController : Controller
    {
        // GET: Off
        public ActionResult Index()
        {

            HttpContext.Session.Remove(Const.SESSION_USER);
            return Redirect(Const.PREPAGE);
        }
    }
}