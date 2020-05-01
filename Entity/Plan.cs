using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity
{
    public class Plan
    {
        [Required(ErrorMessage = "标题不能为空")]
        public string Title { set; get; }

        public string Other { set; get; }

        [Required(ErrorMessage = "标签不能为空")]
        public string Tags { set; get; }

        [Required(ErrorMessage = "开始时间不能为空")]
        public int StartTime { set; get; }

        [Required(ErrorMessage = "结束时间不能为空")]
        public int EndTime { set; get; }

        public int Leave { set; get; }

        public string Evidence { set; get; }

        public string WebAdress { set; get; }

        public int Helper { set; get; }


        [Required(ErrorMessage ="惩罚金不能为空呦")]
        public string Coin { set; get; }

        public bool Continue { set; get; }

    }
}
