﻿using System;
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
