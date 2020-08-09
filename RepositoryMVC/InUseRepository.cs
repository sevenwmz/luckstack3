using EntityMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace RepositoryMVC
{
    public class InUseRepository : BaceRepository<InUseDate>
    {
        public InUseRepository(SqlContext context) :base(context)
        {

        }

        public IList<InUseDate> GetUsedAdPositionDateBy(int positionId)
        {
            return entities.Include(a=>a.UsedBy)
                        .Where(a => a.AdPositionId == positionId)
                        .ToList()
                        ;
        }

    }
}
