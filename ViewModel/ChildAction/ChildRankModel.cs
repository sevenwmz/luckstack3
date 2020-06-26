using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.ChildAction
{
    public class ChildRankModel
    {
        public int Id { set; get; }
        public string UserName { set; get; }
        public int Level { set; get; }
        public int BMoney { set; get; }

        public List<ChildRankModel> Items { set; get; }

    }
}
