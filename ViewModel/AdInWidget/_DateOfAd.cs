using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.AdInWidget
{
    public class _DateOfAd
    {
        public int Id { set; get; }
        public int PositionId { set; get; }
        public IList<InUseDate> AdPosition { set; get; }
    }

    public class InUseDate
    {
        public int Id { set; get; }
        public DateTime UsedDay { set; get; }
        public int AdPositionId { set; get; }
        public UserModel UsedBy { set; get; }
    }
}
