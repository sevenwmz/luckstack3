using ProductServices.Log;
using System;
using System.Web;
using System.Web.Mvc;
using ViewModel.Log;
using WebUI.UIFunction;
using Global;
using ProductServices;

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
                return View(model);
            }
            if (model.Captcha != Session[Const.SESSION_CAPTCHA].ToString())
            {
                return View(model);
            }


            OnService logIn = new OnService();
            OnModel user = logIn.GetByName(model.LogInName);
            if (user == null)
            {
                ModelState.AddModelError(model.LogInName, "用户名不正确，要不要在想一想");
                return View(model);
            }
            if (user.Password != model.Password.Md5Encrypt())
            {
                ModelState.AddModelError(model.Password, "密码不正确，要不要在想一想");
                return View(model);
            }



            //Add cookie
            CookieHelper.AddCookie(user.Id, user.Password, model.RemenberMe);
            if (Request.QueryString[Const.PREPAGE] == null)
            {
                return RedirectToRoute("ArticleIndex");
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
            return RedirectToAction("on");
        }

    }

}