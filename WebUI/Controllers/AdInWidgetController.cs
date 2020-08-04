using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.AdInWidget;

namespace WebUI.Controllers
{
    public class AdInWidgetController : Controller
    {
        // GET: AdInWidget
        public ActionResult Write()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Write(WriteModel model)
        {
            return View();
        }
    }
}