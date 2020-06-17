using ProductServices.Log;
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

            OnService logIn = new OnService();
            OnModel user = logIn.GetByName(model.LogInName);
            if (user == null)
            {
                ModelState.AddModelError(model.LogInName, "用户名不正确，要不要在想一想");
                return View(model);
            }
            if (user.Password != model.Password)
            {
                ModelState.AddModelError(model.Password, "密码不正确，要不要在想一想");
                return View(model);
            }

            HttpContext.Session.Add(Const.SESSION_USER, Const.SESSION_VALUE);
            if (model.RemenberMe)
            {
                HttpContext.Session.Timeout = Convert.ToInt32(DateTime.Now.AddDays(1));
            }

            if (Request.QueryString == null)
            {
                return View("~/Article");
            }
            return Redirect(Request.QueryString[Const.PREPAGE]);
        }
    }
}