using EntityMVC;
using RepositoryMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Log;

namespace ProductServices.Log
{
    public class OnService : BaceService
    {
        /// <summary>
        /// Connection to userRepository
        /// </summary>
        private UserRepository _userRepository;

        public OnService()
        {
            _userRepository = new UserRepository(dbContext);
        }

        /// <summary>
        /// Check logIn user info correct,return User all info
        /// </summary>
        /// <param name="name">Need user name</param>
        /// <returns>Return User all info</returns>
        public OnModel GetByName(string name)
        {
            User userInfo = _userRepository.GetBy(name);
            return connectedMapper.Map<OnModel>(userInfo);
        }

    }
}
