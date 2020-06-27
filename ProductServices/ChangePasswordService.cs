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
                user = repo.Find(26);
                user.Password = newInfo.NewPwd;
            }
            catch (Exception)
            {
                //fake to save to file...
                throw;
            }
        }
    }
}
