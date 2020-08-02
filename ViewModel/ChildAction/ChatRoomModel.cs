using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.ChildAction
{
    public class ChatRoomModel
    {
        public int? CurrentUserId { set; get; }
        public IList<ChatItemModel> ChatItems { set; get; }
    }

    public class ChatItemModel
    {
        public int Id { set; get; }

        public DateTime PublishTime { set; get; }
        public string Content { set; get; }
        public UserModel Author { set; get; }
        public ChatItemModel Reply { set; get; }

    }

    public class ChatAjaxModel
    {
        public int Id { set; get; }
        public DateTime PublishTime { set; get; }
        public string Content { set; get; }
        public UserModel Author { set; get; }
        public int? ReplyId { set; get; }

    }
}
