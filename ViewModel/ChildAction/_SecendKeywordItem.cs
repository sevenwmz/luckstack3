using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.ChildAction
{
    public class _SecendKeywordItem
    {
        public IList<Item> Items { set; get; }
    }

    public class Item
    {
        public int Id { set; get; }
        public string SecendKeywordName { set; get; }
    }
}
