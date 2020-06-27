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



    }
}
