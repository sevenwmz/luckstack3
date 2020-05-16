using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity
{
    public class MessageMine
    {
        public int Id { set; get; }
        public DateTime PublishTime { set; get; }
        public MessageStatus Status { set; get; }
        public string Content { set; get; }
        public bool HasRead { set; get; }
        public bool HasCheck { set; get; }
    }

    public enum MessageStatus
    {
        [Description("刷新")]
        Refresh,
        [Description( "被人捡走")]
        SomeOnePickUp,
        [Description( "目标")]
        Target,
        [Description( "自动撤销")]
        AutoCancle,
        [Description( "邀请帮忙")]
        InviteHelp,
        [Description( "有打赏")]
        HaveReward

    }
}
