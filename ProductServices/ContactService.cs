using EntityMVC;
using RepositoryMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Contact;

namespace ProductServices
{
    public class ContactService : BaceService
    {
        /// <summary>
        /// Add current user contact to database
        /// </summary>
        /// <param name="model">Need info</param>
        public void Add(ContactModel model)
        {
            Contact contact = Mapper.Map<Contact>(model);
            contact.Owner = CurrenUser;
            contact.Owner.EmailAddress.Address = model.Email;
            new ContactRepository(dbContext).AddContact(contact);
        }

        public void Change(ContactModel model)
        {
            Mapper.Map(
                model,new ContactRepository(dbContext).FindContact(CurrentUserId));
        }

        public ContactModel GetContactInfo()
        {
            return Mapper.Map<ContactModel>(new ContactRepository(dbContext).GetCurrentUserInfo(CurrenUser));
        }
    }
}
