using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.Problem;

namespace WebUI.Controllers
{
    public class ProblemController : Controller
    {
        // GET: Problem
        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        public ActionResult New(ProblemNewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }







            return View();
        }
    }
}