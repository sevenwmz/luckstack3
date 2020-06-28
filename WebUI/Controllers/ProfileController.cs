using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.Profile;

namespace WebUI.Controllers
{
    public class ProfileController : BaseController
    {
        // GET: Profile
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