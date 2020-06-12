using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HomeWork_Of_EFCore
{
    public class Message : BaceEntity
    {
        public string Content { set; get; }
        public DateTime PublishTime { set; get; }
        public bool HasRead { set; get; }
        public bool HasCheck { set; get; }
        public MessageStatus MessageStatus { set; get; }
        public string OwnerName { set; get; }
        public User Owner { set; get; }
    }
    public enum MessageStatus
    {
        [Description("刷新")]
        Refresh,
        [Description("被人捡走")]
        SomeOnePickUp,
        [Description("目标")]
        Target,
        [Description("自动撤销")]
        AutoCancle,
        [Description("邀请帮忙")]
        InviteHelp,
        [Description("有打赏")]
        HaveReward

    }
}
