using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.ChildAction
{
    public class ChatRoomModel
    {
        public IList<ChatItemModel> ChatRooms { set; get; }
    }

    public class ChatItemModel
    {
        public int Id { set; get; }

        public DateTime PublishTime { set; get; }
        public string Content { set; get; }
        public User Author { set; get; }
        public ChatItemModel Reply { set; get; }

    }

    public class User
    {
        public int AuthorId { set; get; }
        public string Author { set; get; }
        public int Level { set; get; }
    }

}
