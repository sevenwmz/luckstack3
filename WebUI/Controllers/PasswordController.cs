using ProductServices;
using Global;
using System.Web.Mvc;
using ViewModel.Password;

namespace WebUI.Controllers
{
    public class PasswordController : BaseController
    {

        #region ChangePassword
        // GET: Password
        public ActionResult Change()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Change(ChangeModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Change");
            }
            ChangePasswordService changePwd = new ChangePasswordService();

            if (changePwd.GetUserPassword() != model.OldPwd/*.Md5Encrypt()*/)
            {
                ModelState.AddModelError(model.OldPwd, "老的密码不对不对，想想看！！！");
                return View(model);
            }

            model.NewPwd = model.NewPwd.Md5Encrypt();
            changePwd.AddNewPwd(model);

            return View();
        }
        #endregion


    }
}