using EntityMVC;
using RepositoryMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void AddNewPwd(string newPassword)
        {
            try
            {
                connectedMapper.Map(
                   newPassword, new UserRepository(dbContext).Find(CurrentUserId).Password);
            }
            catch (Exception)
            {
                //fake to save to file...
                throw;
            }
        }
    }
}
