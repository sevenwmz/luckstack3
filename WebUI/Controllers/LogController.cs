using ProductServices.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.Log;

namespace WebUI.Controllers
{
    public class LogController : BaseController
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

            HttpCookie logIncookie = new HttpCookie(Const.COOKIE_NAME);
            logIncookie.Values["id"] = user.Id.ToString();
            logIncookie.Values["pwd"] = user.Password;
            Response.Cookies.Add(logIncookie);
            if (model.RemenberMe)
            {
                logIncookie.Expires = DateTime.Now.AddDays(15);
            }
            HttpContext.Response.Cookies.Add(logIncookie);

            if (Request.QueryString == null)
            {
                return View("~/Article");
            }
            return Redirect(Request.QueryString[Const.PREPAGE]);
        }




        // GET: Off
        /// <summary>
        /// Log/Off
        /// </summary>
        /// <returns></returns>
        public ActionResult Off()
        {
            HttpContext.Response.Cookies.Clear();
            return Redirect(Request.QueryString[Const.PREPAGE]);
        }

    }

}