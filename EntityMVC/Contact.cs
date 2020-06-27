using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityMVC
{
    public class Contact : BaceEntity
    {
        public string QQ { set; get; }
        public string WeChat { set; get; }
        public int? CellPhone { set; get; }
        public string OtherMark { set; get; }
        public int OwnerId { set; get; }
        public User Owner { set; get; }
    }
}
