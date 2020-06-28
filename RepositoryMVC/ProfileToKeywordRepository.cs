using EntityMVC;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryMVC
{
    public class ProfileToKeywordRepository : BaceRepository<ProfileToKeyword>
    {
        public ProfileToKeywordRepository(DbContext context) : base(context)
        {

        }



    }
}
