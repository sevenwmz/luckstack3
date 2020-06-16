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
        public string Detail { set; get; }
        public int Freezing { set; get; }
        public int LeftBMoney { set; get; }
        public int LeftBPoint { set; get; }
        public BMoneyDirection Status { set; get; }

        /// <summary>
        /// Register award Bmoney
        /// </summary>
        /// <returns>Return Bmoney</returns>
        public BMoney RegisterAwardBMoney()
        {
            BMoney awardRegister = new BMoney
            {
                Latestime = DateTime.Now,
                Detail = "Register award 10 BMoney",
                Freezing = 0,
                LeftBMoney = 10,
                LeftBPoint = 0,
                Status = BMoneyDirection.BMoneyOrBPointIn
            };
            return awardRegister;
        }
        /// <summary>
        /// Add new info to 
        /// </summary>
        /// <param name="inviter"></param>
        /// <returns></returns>
        public BMoney GiveInviterPrize(string inviter)
        {
            MvcRepository repository = new MvcRepository();

            User user = repository.UsersInfo
                .Where(u => u.Inviter == inviter).FirstOrDefault();

            BMoney bMoney = repository.BMoneys
                .OrderByDescending(b=>b.Latestime).Where(b => b.OwnerId == user.Id).FirstOrDefault();

            BMoney awardRegister = new BMoney
            {
                OwnerId = user.Id,
                Latestime = DateTime.Now,
                Detail = "Inviter award 10 BMoney",
                Freezing = bMoney.Freezing + 0,
                LeftBMoney = bMoney.LeftBMoney + 10,
                LeftBPoint = bMoney.LeftBPoint + 0,
                Status = BMoneyDirection.BMoneyOrBPointIn
            };
            return awardRegister;
        }

    }
    public enum BMoneyDirection
    {
        [Display(Name = "支出")]
        BMoneyOrBPointOut,

        [Display(Name = "收入")]
        BMoneyOrBPointIn,

        [Display(Name = "冻结")]
        BMoneyOrBPointFreezing
    }
}
