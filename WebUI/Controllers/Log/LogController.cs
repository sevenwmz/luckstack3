using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.Log;

namespace WebUI.Controllers
{
    public class LogController : Controller
    {
        // GET: On
        public ActionResult On()
        {
            return View();
        }

        [HttpPost]
        public ActionResult On(OnModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            return View();
        }
    }
}