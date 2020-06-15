using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityMVC
{
    public class BMoney : BaceEntity
    {
        public int OwnerId { set; get; }
        public User Owner { set; get; }
        public DateTime Latestime { set; get; }
        public BMoneyDirection 
    }
    public enum BMoneyDirection
    {
        [Display(Name = "支出")]
        MoneyOrBPointOut,

        [Display(Name = "收入")]
        MoneyOrBPointIn,

        [Display(Name = "冻结")]
        MoneyOrBPointFreezing
    }
}
