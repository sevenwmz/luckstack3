using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_Of_EFCore
{
    public class Email : BaceEntity
    {
        public string EmailLocation { set; get; }
        public string Remark { set; get; }
        //public int? FromWhoId { set; get; }
        public User FromWho { set; get; }
    }
}
