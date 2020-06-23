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
        public int Change { set; get; }
        public int LeftBMoney { set; get; }
        public BMoneyDirection Status { set; get; }

        /// <summary>
        /// Register award Bmoney
        /// </summary>
        /// <returns>Return Bmoney</returns>
        public BMoney RegisterAwardBMoney()
        {
            return new BMoney
            {
                Latestime = DateTime.Now,
                Detail = "Register award 10 BMoney",
                Freezing = 0,
                LeftBMoney = 10,
                Change = 10,
                Status = BMoneyDirection.BMoneyIn
            };
        }

        public BMoney PublicArticleMinusBMoney(BMoney bMoney)
        {
            return new BMoney
            {
                OwnerId = bMoney.OwnerId,
                Latestime = DateTime.Now,
                LeftBMoney = --bMoney.LeftBMoney,
                Status = BMoneyDirection.BMoneyOut,
                Freezing = 0,
                Change = -1,
                Detail = "Publish article minus BMoney one"
            };

        }

        public BMoney GiveInviterPrize(BMoney bMoney)
        {
            return new BMoney
            {
                OwnerId = bMoney.Id,
                Latestime = DateTime.Now,
                Detail = "Inviter success award 10 BMoney",
                Freezing = bMoney.Freezing + 0,
                Change = 10,
                LeftBMoney = bMoney.LeftBMoney + 10,
                Status = BMoneyDirection.BMoneyIn
            };
        }

        public BMoney PublicProblemMinusBMoney(int RewardMoney, BMoney bMoney)
        {
            return new BMoney
            {
                OwnerId = bMoney.OwnerId,
                Latestime = DateTime.Now,
                Detail = $"Publish Problem success Reward {RewardMoney} BMoney",
                Freezing = bMoney.Freezing + RewardMoney,
                Change = RewardMoney,
                LeftBMoney = bMoney.LeftBMoney - RewardMoney,
                Status = BMoneyDirection.BMoneyFreezing
            };
        }
    }
    public enum BMoneyDirection
    {
        [Display(Name = "帮帮币支出")]
        BMoneyOut,

        [Display(Name = "帮帮币收入")]
        BMoneyIn,

        [Display(Name = "帮帮币冻结")]
        BMoneyFreezing
    }
}
