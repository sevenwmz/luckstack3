using EntityMVC;
using RepositoryMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace ProductServices
{
    public class RegisterService
    {
        /// <summary>
        /// Connection to userRepository
        /// </summary>
        private UserRepository userInfo;

        public RegisterService()
        {
            userInfo = new UserRepository();
        }

        /// <summary>
        /// Get inviter exist in database
        /// </summary>
        /// <param name="name">Need inviter name</param>
        /// <returns>Return one of RegisterModel Info</returns>
        public RegisterModel GetName(string name)
        {
            RegisterModel model = new RegisterModel();
            User userInfo = new User();
            userInfo = this.userInfo.GetBy(name);

            if (userInfo.Inviter == null)
            {
                return null;
            }

            model = new RegisterModel
            {
                Inviter = userInfo.Inviter,
                InviterNumber = userInfo.InviterNumber,
                UserName = userInfo.UserName,
                Password = userInfo.Password
            };
            return model;
        }

        /// <summary>
        /// Add award and constitute registerInfo ,add to reposiroty.
        /// </summary>
        /// <param name="registerInfo">Need registerInfo</param>
        public void Add(RegisterModel registerInfo)
        {
            User register = new User
            {
                Inviter = registerInfo.Inviter,
                InviterNumber = registerInfo.InviterNumber,
                UserName = registerInfo.UserName,
                Password = registerInfo.Password,
            };
            userInfo.Register(register);
        }
    }
}
