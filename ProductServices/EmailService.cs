using EntityMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices
{
    public class EmailService : BaceService
    {
        private User _repoUser;
        public EmailService()
        {
            _repoUser = new User();
        }

        public bool Activate(int userId,string code)
        {
            _repoUser = UserRepository.Find(userId);
            if (_repoUser.EmailAddress.Expire == null)
            {
                return false;
            }
            return code == _repoUser.EmailAddress.Code;
        }

        public void AddHasValid(int id)
        {
            _repoUser = UserRepository.Find(id);
            _repoUser.EmailAddress.IsActive = true;
            UserRepository.Update(_repoUser);
        }
    }
}
