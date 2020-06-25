using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Problem
{
    public class ProblemItemModel
    {
        public int ProblemId { set; get; }
        public DateTime PublishTime { set; get; }
        public int AuthorId { set; get; }
        public string Author { set; get; }
        public int Level { set; get; }
        public string Title { set; get; }
        public string Body { set; get; }
        public string Summary { set; get; }
        public ProblemStatus Status { set; get; }
        public IList<KeywordsModel> ListKeywords { set; get; }

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
