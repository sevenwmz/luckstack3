using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.ChildAction
{
    public class ChildCommentModel
    {
        public int? CurrentId { set; get; }
        public IList<ChildCommentItem> Comments { set; get; }
    }


    public class ChildCommentItem
    {
        public int Id { set; get; }
        public DateTime PublishTime { set; get; }
        public UserModel Author { set; get; }
        public string Comment { set; get; }
        public ChildCommentItem Reply { set; get; }
        public int Agree { set; get; }
        public int DisAgree { set; get; }
    }
}
