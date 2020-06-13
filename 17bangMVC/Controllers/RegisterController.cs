using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace _17bangMVC.Controllers
{
    public class RegisterController : Controller
    {

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

            //User user = new User
            //{
            //    Inviter = this.Inviter,
            //    InviterNumber = this.InviterNumber,
            //    UserName = this.UserName,
            //    Password = this.Password
            //};

            #region Check Info Is Correct
            //UserRepository repository = new UserRepository();
            //if (!repository.CheckInvitedName(user.Inviter))
            //{
            //    ModelState.AddModelError(nameof(Inviter), "用邀请人不正确呦");
            //    return Page();
            //}//eles nothing
            //if (!repository.CheckInviteCode(user.InviterNumber))
            //{
            //    ModelState.AddModelError(nameof(InviterNumber), "邀请码不正确呦");
            //    return Page();
            //}//eles nothing
            //if (!repository.UserNameHasRepeat(user.UserName))
            //{
            //    ModelState.AddModelError(nameof(UserName), "用户名已存在呦，换一个吧");
            //    return Page();
            //}//eles nothing
            #endregion

            //_userRepository.Save(user);




            //HttpContext.Session.SetString(Const.COOKIE_USER, Const.COOKIE_VALUE);
            //Response.Cookies.Append(Const.COOKIE_USER, Const.COOKIE_VALUE);
            //LogOnModel.IsLogIn = true;
            //return Redirect(Request.Query[Const.PREPAGE]);
            return View();
        }
    }
}