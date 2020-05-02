using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _17bang.Repository
{
    public class UserRepository
    {
        private static IList<User> _users { set; get; }

        static UserRepository()
        {
            _users = new List<User>
            {
                new User{UserName = "wpzwpz",Password = "1234"},
                new User{UserName = "atai",Password = "1234"},
                new User{UserName = "yefei",Password = "1234"},
            };
        }

        public User GetByName(string userName)
        {
            return _users.Where(u => u.UserName == userName).SingleOrDefault();
        }
    }
}
