﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Contact
{
    public class ContactModel
    {
        public string QQ { set; get; }
        public string WeChat { set; get; }
        public int? CellPhone { set; get; }
        public string OtherMark { set; get; }
        [Required(ErrorMessage = "Email不能为空")]
        public string Email { set; get; }

    }
}
