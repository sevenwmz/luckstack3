using EntityMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryMVC
{
    public class AdDateRepository : BaceRepository<InUseDate>
    {
        public AdDateRepository(SqlContext context) :base(context)
        {

        }
    }
}
