using EntityMVC;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryMVC
{
    public class UserRepository : BaceRepository<User>
    {
        public UserRepository(DbContext content) : base(content)
        {

        }
        /// <summary>
        /// Get ChildRank by user level in front of 8
        /// </summary>
        /// <returns>Return 8 user and money</returns>
        public IList<User> GetUserRank(int takeRankNum)
        {
            return entities
                    .Include(u => u.Wallet)
                    .OrderByDescending(u => u.Level)
                    .Take(takeRankNum)
                    .ToList()
                    ;
        }

        /// <summary>
        /// Get Inviter From Database
        /// </summary>
        /// <param name="name">Need Inviter Name</param>
        /// <returns>Return inviterInfo</returns>
        public User GetBy(string name)
        {
            return entities.Where(u => u.UserName == name).FirstOrDefault();
        }

        public void Update(User repoUser)
        {
            entities.Attach(repoUser);
            context.SaveChanges();
        }

        /// <summary>
        /// Add data to database.
        /// </summary>
        /// <param name="regiserInfo">Need userInfo</param>
        public int AddRegisterToDatabase(User regiserInfo)
        {
            entities.Add(regiserInfo);
            context.SaveChanges();
            return regiserInfo.Id;
        }
    }
}
