using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityMVC
{
    public class Profile : BaceEntity
    {
        public int OwnerId { set; get; }
        public User Owner { set; get; }
        public bool Gender { set; get; }
        public DateTime BornTime { set; get; }
        public string SelfIntroduce { set; get; }
        public string Constellation { set; get; }
        public IList<ProfileToKeyword> keyword { set; get; }

    }
}
