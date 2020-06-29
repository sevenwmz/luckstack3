using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityMVC
{
    public class MessageMine : BaceEntity
    {
        public bool HasRead { set; get; }
        public string Content { set; get; }
        public DateTime PublishTime { set; get; }
        public MessageStatus MessageStatus { set; get; }
        public int OwnerId { set; get; }
        public User Owner { set; get; }
    }

    public enum MessageStatus
    {
        Refresh,
        SomeOnePickUp,
        Target,
        AutoCancle,
        InviteHelp,
        HaveReward
    }


}
