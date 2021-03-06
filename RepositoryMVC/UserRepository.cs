﻿using EntityMVC;
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

        public User GetLogOnInfo(int userId)
        {
            return entities.Include(m => m.Wallet).Where(u=>u.Id == userId).FirstOrDefault();
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

        public User FindBy(string emailAddress)
        {
            return entities.Where(u => u.EmailAddress.Address == emailAddress).FirstOrDefault();
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

        public User FindUserCodeBy(string email)
        {
            return entities.Where(u => u.EmailAddress.Address == email).FirstOrDefault();
        }

        public User FindUserBy(string code)
        {
            return entities.Where(u => u.EmailAddress.Code == code).FirstOrDefault();
        }
    }
}
