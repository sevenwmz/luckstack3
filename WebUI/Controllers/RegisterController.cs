using Global;
using ProductServices;
using System.Web.Mvc;
using ViewModel;
using WebUI.UIFunction;

namespace WebUI.Controllers
{
    public class RegisterController : BaseController
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
            if (model.Captcha != Session[Const.SESSION_CAPTCHA].ToString())
            {
                return View(model);
            }

            RegisterService registerService = new RegisterService();
            #region Check RegisterInfo Is Correct
            RegisterModel inviter = registerService.GetByName(model.Inviter);
            if (inviter == null)
            {
                ModelState.AddModelError(nameof(model.Inviter), "邀请人是不是填错啦");
                return View(model);
            }
            if (inviter.InviterNumber != model.InviterNumber)
            {
                ModelState.AddModelError(nameof(model.InviterNumber), "邀请码是不是填错啦！");
                return View(model);
            }
            if (registerService.GetByName(model.UserName) != null)
            {
                ModelState.AddModelError(nameof(model.UserName), "换个名字吧，这个名字已经被人抢先一步占用了。");
                return View(model);
            }
            #endregion
            int registerId = registerService.Add(new RegisterModel
            {
                Inviter = model.Inviter,
                InviterNumber = model.InviterNumber,
                UserName = model.UserName,
                Password = model.Password.Md5Encrypt()
            });

            //Add cookie
            CookieHelper.AddCookie(registerId, model.Password.Md5Encrypt());
            if (Request.QueryString == null)
            {
                return View("/Article");
            }
            return Redirect(Request.QueryString[Const.PREPAGE]);
        }



    }
}