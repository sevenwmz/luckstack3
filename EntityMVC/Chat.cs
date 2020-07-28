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
        public string Content { set; get; }
        public int AuthorId { set; get; }
        public User Author { set; get; }


        public int? ReplyId { set; get; }
        public Chat Reply { set; get; }



    }
}
