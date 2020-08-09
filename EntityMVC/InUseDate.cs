using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityMVC
{
    public class InUseDate : BaceEntity
    {
        public DateTime UsedDay { set; get; }
        public int AdPositionId { set; get; }
        public AdDate AdPosition { set; get; }
        public int UsedById { set; get; }
        public User UsedBy { set; get; }
    }
}
