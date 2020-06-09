using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_Of_EFCore
{
    //[Table("Register")]
    public class User : BaceEntity
    {
        //[MaxLength(50)]
        //[Key]
        //[Column("UserName")]
        public string Name { set; get; }
        //[Required]
        public string Password { set; get; }
        public DateTime CreateTime { set; get; }
        //[NotMapped]
        public int FailedTry { set; get; }
        public int? SendToId { set; get; }
        public Email SendTo { set; get; }
    }
}
