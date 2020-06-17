using EntityMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryMVC
{
    public class UserRepository
    {
        /// <summary>
        /// Private Connect Proprety
        /// </summary>
        private SqlContext _context;

        public UserRepository()
        {
            _context = new SqlContext();
        }

        /// <summary>
        /// Get Inviter From Database
        /// </summary>
        /// <param name="name">Need Inviter Name</param>
        /// <returns>Return inviterInfo</returns>
        public User GetBy(string name)
        {
            return _context.Users.Where(u => u.UserName == name).FirstOrDefault();
        }

        /// <summary>
        /// Add data to database.
        /// </summary>
        /// <param name="regiserInfo">Need userInfo</param>
        public int AddRegisterToDatabase(User regiserInfo)
        {
            _context.Users.Add(regiserInfo);
            _context.SaveChanges();
            return regiserInfo.Id;
        }





    }
}
