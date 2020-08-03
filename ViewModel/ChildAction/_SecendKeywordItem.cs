using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.ChildAction
{
    public class _SecendKeywordModel
    {
        public IList<_SecendKeywordItem> Items { set; get; }
    }

    public class _SecendKeywordItem
    {
        public int Id { set; get; }
        public int Used { set; get; }
        public string SecendKeywordName { set; get; }
    }
}
