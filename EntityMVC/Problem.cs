using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityMVC
{
    public class Problem : BaceEntity
    {
        public string Title { set; get; }
        public string Body { set; get; }
        public bool NeedRemoteHelp { set; get; }
        public int RewardMoney { set; get; }
        public ProblemStatus Status { set; get; }
        public User HelpFrom { set; get; }
        public DateTime PublishTime { set; get; }
        public User Author { set; get; }
        public IList<KeywordsAndProblem> OwnKeyword { set; get; }

    }
    public enum ProblemStatus
    {
        [Display(Name = "已撤销")]
        cancelled,
        [Display(Name = "已酬谢")]
        Rewarded,
        [Display(Name = "协助中")]
        inprocess,
        [Display(Name = "待协助")]
        assist
    }

}
