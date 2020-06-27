using EntityMVC;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryMVC
{
    public class ContactRepository : BaceRepository<Contact>
    {
        public ContactRepository(DbContext context) : base(context)
        {
        }

        /// <summary>
        /// Add current user info to db
        /// </summary>
        /// <param name="contact">Need info</param>
        public void AddContact(Contact contact)
        {
            entities.Add(contact);
        }

        /// <summary>
        /// Return current user info
        /// </summary>
        /// <param name="currenUser">Need current user</param>
        /// <returns>Return current user info</returns>
        public Contact GetCurrentUserInfo(User currenUser)
        {
            return entities.Where(c => c.OwnerId == currenUser.Id).FirstOrDefault();
        }

        public Contact FindContact(int? currentUserId)
        {
            return  entities.Where(c => c.OwnerId == currentUserId.Value).FirstOrDefault();
        }

        public void SaveAfterChange(Contact contact)
        {
            entities.Attach(contact);
        }
    }
}
