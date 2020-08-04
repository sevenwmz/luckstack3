using ProductServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class AdController : Controller
    {


        // GET: Ad
        [ChildActionOnly]
        public ActionResult Index()
        {
            return View(new AdService().GetChildAD());
        }

    }
}