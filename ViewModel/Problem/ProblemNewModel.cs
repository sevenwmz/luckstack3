using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ViewModel.Problem
{
    public class ProblemNewModel
    {
        public  int Id { set; get; }
        public bool NeedRemoteHelp { set; get; }
        public bool HasLeftMoney { set; get; }
        public string NeedSubKeyword { set; get; }
        public string HelpFrom { set; get; }


        [Required(ErrorMessage = "标题不能为空")]
        public string Title { set; get; }

        [Required(ErrorMessage = "内容不能为空")]
        public string Body { set; get; }

        [Required(ErrorMessage = "悬赏不能为空，最少1个帮帮币")]
        public int RewardMoney { set; get; }

        public IList<KeywordModel> Keywords { set; get; }
        public int? FristDropDownKeywordsId { set; get; }
        public IList<SelectListItem> FristDropDownKeywords { set; get; }
        public int? SecendDropDownKeywordsId { set; get; }
        public IList<SelectListItem> SecendDropDownKeywords { set; get; }
    }
}
