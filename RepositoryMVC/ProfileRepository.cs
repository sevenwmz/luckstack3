using EntityMVC;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryMVC
{
    public class ProfileRepository :BaceRepository<Profile>
    {
        public ProfileRepository(DbContext context) :base(context)
        {

        }

        public int AddUserInfo(Profile profile)
        {
            entities.Add(profile);
            context.SaveChanges();
            return profile.Id;
        }

    }
}
