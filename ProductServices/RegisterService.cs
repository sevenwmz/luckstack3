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
    public class RegisterService : BaceService
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
            User userInfo = new User();
            userInfo = this.userInfo.GetBy(name);

            if (userInfo.Inviter == null)
            {
                return null;
            }
            RegisterModel model = connectedMapper.Map<RegisterModel>(userInfo);

            return model;
        }

        /// <summary>
        /// Add award and constitute registerInfo ,add to reposiroty.
        /// </summary>
        /// <param name="registerInfo">Need registerInfo</param>
        public int Add(RegisterModel registerInfo)
        {
            User register = connectedMapper.Map<User>(registerInfo);
            return userInfo.Register(register);
        }
    }
}
