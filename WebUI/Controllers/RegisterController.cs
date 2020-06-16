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
            return View();
        }


        [HttpPost]
        public ActionResult Index(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            RegisterService registerService = new RegisterService();

            #region Check RegisterInfo Is Correct
            RegisterModel fromPage = new RegisterModel();
            RegisterModel registerInfo = new RegisterModel();

            registerInfo = registerService.GetName(model.Inviter);

            if (string.IsNullOrEmpty(registerInfo.Inviter))
            {
                ModelState.AddModelError(nameof(model.Inviter), "邀请人是不是填错啦");
                return View();
            }
            if (registerInfo.InviterNumber != model.InviterNumber)
            {
                ModelState.AddModelError(nameof(model.InviterNumber), "邀请码是不是填错啦！");
                return View();
            }
            if (registerInfo.UserName == model.UserName)
            {
                ModelState.AddModelError(nameof(model.UserName), "换个名字吧，这个名字已经被人抢先一步占用了。");
                return View();
            }
            #endregion

            registerService.Add(new RegisterModel
            {
                Inviter = model.Inviter,
                InviterNumber = model.InviterNumber,
                UserName = model.UserName,
                Password = model.Password
            });

            HttpContext.Session.Add(Const.SESSION_USER, Const.SESSION_VALUE);
            if (Request.QueryString == null)
            {
                return View("~/Article");
            }
            return Redirect(Request.QueryString[Const.PREPAGE]);
        }



    }
}