using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.ChildAction
{
    public class ChildADModel
    {
        public int Id { set; get; }
        public string ContentOfAd { set; get; }
        public IList<ChildADModel> Items { set; get; }
    }
}
