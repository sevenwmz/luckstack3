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
        public DateTime PublishTime { set; get; }
        public string User { set; get; }
        public int Level { set; get; }
        public string MyChatContent { set; get; }


    }
}
