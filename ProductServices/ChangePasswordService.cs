using EntityMVC;
using RepositoryMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Password;

namespace ProductServices
{
    public class ChangePasswordService : BaceService
    {
        /// <summary>
        /// From DB take userInfo 
        /// </summary>
        /// <returns>Return currentUser pwd</returns>
        public string GetUserPassword()
        {
            return new UserRepository(dbContext).Find(CurrentUserId).Password;
        }

        public void AddNewPwd(ChangeModel newInfo)
        {
            try
            {
                User user = new User();
                UserRepository repo = new UserRepository(dbContext);
                user = repo.Find(CurrentUserId);
                user.Password = newInfo.NewPwd;
            }
            catch (Exception)
            {
                //fake to save to file...
                throw;
            }
        }

        public ForgetModel FindUserInfo(ForgetModel model)
        {
            User user = new User();
            if (model.EmailAddress != null)
            {
                user = UserRepository.FindBy(model.EmailAddress);
            }
            else if (model.UserName != null)
            {
                user = UserRepository.GetBy(model.UserName);
            }
            else
            {
                return null;
            }

            ForgetModel forgetModel = Mapper.Map<ForgetModel>(user);
            forgetModel.EmailAddress = user.EmailAddress.Address;
            return forgetModel;
        }

        public void AddVerifyCode(ForgetModel model,int verifyCode)
        {
            User user = new User();
            if (model.EmailAddress != null)
            {
                user = UserRepository.FindBy(model.EmailAddress);
            }
            else if (model.UserName != null)
            {
                user = UserRepository.GetBy(model.UserName);
            }
            user.EmailAddress.Code = verifyCode.ToString();
            user.EmailAddress.Expire = DateTime.Now.AddMinutes(10);
        }

        public ResetModel GetUserVerifyCode(string email)
        {
            User user = new User();
            user = UserRepository.FindUserCodeBy(email);

            ResetModel resetModel = new ResetModel();
            if (user.EmailAddress.Expire == null)
            {
                return null;
            }
            resetModel.VerifyCode = user.EmailAddress.Code;
            return resetModel;
        }

        public void ChangeNewPassword(string code,string password)
        {
            User user = new User();
            user = UserRepository.FindUserBy(code);
            user.Password = password;
        }
    }
}
