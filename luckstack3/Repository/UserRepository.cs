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
                new User{UserName = "王胖子",Password = "1234",Level = "9",Integral = 999},
                new User{UserName = "阿泰",Password = "1234",Level = "8",Integral = 499},
                new User{UserName = "叶飞",Password = "1234",Level = "3",Integral = 929},
                new User{UserName = "老刘",Password = "1234",Level = "5",Integral = 429},
                new User{UserName = "欧阳",Password = "1234",Level = "4",Integral = 339},
                new User{UserName = "wpzwpz",Password = "1234",Level = "7",Integral = 339},
                new User{UserName = "freefly",Password = "1234",Level = "1",Integral = 339},
                new User{UserName = "老王",Password = "1234",Level = "10",Integral = 339},
            };
        }
        public IList<User> Get()
        {
            return _users;
        }
        public User GetByName(string userName)
        {
            return _users.Where(u => u.UserName == userName).SingleOrDefault();
        }
    }
}
