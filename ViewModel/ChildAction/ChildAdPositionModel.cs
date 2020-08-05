using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.ChildAction
{
    public class ChildAdPositionModel
    {
        public int Id { set; get; }
        public UserModel Owner { set; get; }
        public int? ChoosAdPosition { set; get; }
        public int TotalUse { set; get; }
        public int BMoneyLeft { set; get; }
        public IList<ChildAdPositionModel> Items { set; get; }
    }
}
