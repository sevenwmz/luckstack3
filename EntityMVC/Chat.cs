using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityMVC
{
    public class Chat : BaceEntity
    {
        public DateTime PublishTime { set; get; }

        public int? ChatWithId { set; get; }
        public User ChatWith { set; get; }

        public int ChatUserId{ set; get; }
        public User ChatUser { set; get; }

        public string Content { set; get; }
    }
}
