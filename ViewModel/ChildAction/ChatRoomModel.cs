using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.ChildAction
{
    public class ChatRoomModel
    {
        public int Id { set; get; }
        public bool HasChoose { set; get; }
        public DateTime PublishTime { set; get; }

        public int HistoryUserId { set; get; }
        public string HistoryUserName { set; get; }
        public int HistoryUserLevel { set; get; }
        public string HistoryContent { set; get; }

        public int ChatWithId { set; get; }
        public int? ChatWithUserId { set; get; }
        public string ChatWithUserName { set; get; }
        public int? ChatWithUserLevel { set; get; }
        public string ChatWithContent { set; get; }


        public int CurrentUserId { set; get; }
        public string UserName { set; get; }
        public int UserLevel { set; get; }
        public string MyChatContent { set; get; }


        public IList<ChatRoomModel> ChatRooms { set; get; }
    }

}
