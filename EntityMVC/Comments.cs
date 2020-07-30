using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityMVC
{
    public class Comments : BaceEntity
    {
        public DateTime PublishTime { set; get; }
        public string Comment { set; get; }
        public int Agree { set; get; }
        public int DisAgree { set; get; }


        public int? ReplyId { set; get; }
        public Comments Reply { set; get; }


        public int AuthorId { set; get; }
        public User Author { set; get; }


        public int BelongArticleId { set; get; }
        public Article BelongArticle { set; get; }

        public void FillComment(User author)
        {
            this.PublishTime = DateTime.Now;
            this.Author = author;
        }
    }
}
