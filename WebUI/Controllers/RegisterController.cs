using ProductServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;

namespace WebUI.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            ViewData["preRegister"] = Request.QueryString["preRegister"];
            return View();
        }


        [HttpPost]
        public ActionResult Index(int? Id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            RegisterService registerService = new RegisterService();
            #region Check RegisterInfo Is Correct
            RegisterModel fromPage = new RegisterModel();
            RegisterModel InviterInfoExist = new RegisterModel();

            InviterInfoExist = registerService.GetInviterExist(fromPage.Inviter);
            if (string.IsNullOrEmpty(InviterInfoExist.Inviter))
            {
                ModelState.AddModelError(nameof(fromPage.Inviter), "邀请人是不是填错啦");
                return View();
            }
            if (string.IsNullOrEmpty(InviterInfoExist.InviterNumber))
            {
                ModelState.AddModelError(nameof(fromPage.InviterNumber), "邀请码是不是填错啦！");
                return View();
            }

            if (registerService.GetUserNameExist(fromPage.UserName).UserName != null)
            {
                ModelState.AddModelError(nameof(fromPage.UserName),"换个名字吧，这个名字已经被人抢先一步占用了。");
                return View();
            }
            #endregion

            registerService.Add(new RegisterModel 
            {
                Inviter = fromPage.Inviter,
                InviterNumber = fromPage.InviterNumber,
                UserName  = fromPage.UserName,
                Password = fromPage.Password
            });




            //HttpContext.Session.SetString(Const.COOKIE_USER, Const.COOKIE_VALUE);
            //Response.Cookies.Append(Const.COOKIE_USER, Const.COOKIE_VALUE);
            //LogOnModel.IsLogIn = true;
            return Redirect(Request.QueryString["preRegister"]);
            //return View();
        }



    }
}