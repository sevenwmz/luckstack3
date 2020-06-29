using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Message
{
    public class MineModel
    {
        public int Id { set; get; }
        public bool HasCheck { set; get; }
        public bool HasRead { set; get; }
        public string Content { set; get; }
        public int SumOfMessage { set; get; }
        public DateTime PublishTime { set; get; }
        public MessageStatus MessageStatus { set; get; }
        public IList<MineModel> Items { set; get; }
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
