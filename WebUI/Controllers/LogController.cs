﻿using ProductServices.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.Log;
using WebUI.UIFunction;

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

            //Add cookie
            HttpCookie logIncookie = new Cookie().AddCookie(user.Id, user.Password);
            if (model.RemenberMe)
            {
                logIncookie.Expires = DateTime.Now.AddDays(15);
            }
            Response.Cookies.Add(logIncookie);

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
            HttpCookie cookie = HttpContext.Response.Cookies.Get(Const.COOKIE_NAME);
            cookie.Expires = DateTime.Now.AddDays(-100);
            return Redirect(Request.QueryString[Const.PREPAGE]);
        }

    }

}