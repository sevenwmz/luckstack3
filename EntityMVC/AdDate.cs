using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityMVC
{
    public class AdDate : BaceEntity
    {
        public int PositionId { set; get; }
        public IList<InUseDate> AdPosition { set; get; }
    }
}
