using ProductServices;
using Global;
using System.Web.Mvc;
using ViewModel.Password;
using System;

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

            if (changePwd.GetUserPassword() != model.OldPwd.Md5Encrypt())
            {
                ModelState.AddModelError(model.OldPwd, "老的密码不对不对，想想看！！！");
                return View(model);
            }

            model.NewPwd = model.NewPwd.Md5Encrypt();
            changePwd.AddNewPwd(model);

            return View();
        }
        #endregion

        #region Forget Password
        public ActionResult Forget()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Forget(ForgetModel model)
        {
            if (model.Captcha != Session[Const.SESSION_CAPTCHA].ToString())
            {
                ModelState.AddModelError(model.Captcha, "验证码填错啦");
                return View(model);
            }


            ForgetModel forgetModel = new ForgetModel();
            ChangePasswordService service = new ChangePasswordService();

            if (model.EmailAddress != null)
            {
                forgetModel = service.FindUserInfo(model);
                if (model.EmailAddress == forgetModel.EmailAddress)
                {
                    //Add Email
                    EmailVerify(model, service);
                }
            }
            else if (model.UserName != null)
            {
                forgetModel = new ChangePasswordService().FindUserInfo(model);
                if (model.UserName == forgetModel.UserName)
                {
                    //Add Email
                    EmailVerify(model, service);
                }
            }
            else
            {
                ModelState.AddModelError(model.EmailAddress, "哎呀呀，你啥都没写，我猜不到呦");
                return View(model);
            }

            return View();
        }

        private void EmailVerify(ForgetModel model, ChangePasswordService service)
        {
            EmailController email = new EmailController();
            int verifyCode = email.ValideEmail
                    (new ViewModel.EmailModel
                    {
                        EmailAddress = model.EmailAddress,
                        Expire = DateTime.Now.AddMinutes(10),
                        UserName = model.UserName
                    }, "Change Password");
            service.AddVerifyCode(model, verifyCode);
        }
        #endregion

        #region Reset Password
        public ActionResult Reset(string code)
        {
            string email = HttpContext.Request.QueryString["email"].ToString();
            ResetModel resetModel = new ResetModel();
            resetModel = new ChangePasswordService().GetUserVerifyCode(email);
            if (resetModel == null)
            {
                ModelState.AddModelError(resetModel.VerifyCode, "验证时间过期啦，快一点，在快一点。");
            }
            if (code != resetModel.VerifyCode)
            {
                ModelState.AddModelError(resetModel.VerifyCode, "验证码不对，我有一点点问号，是不是填错了呢？");
            }
            return View(code);
        }

        [HttpPost]
        public ActionResult Reset(ResetModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(model.Password, "少些了一些东西呦");
            }
            new ChangePasswordService().ChangeNewPassword(model.VerifyCode,model.Password);

            return View("home/Index");
        }
        #endregion
    }
}