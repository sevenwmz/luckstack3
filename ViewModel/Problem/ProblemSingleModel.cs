using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Problem
{
    public class ProblemSingleModel
    {

        public int Id { set; get; }
        public bool NeedRemoteHelp { set; get; }
        public string Title { set; get; }
        public string Body { set; get; }
        public int RewardMoney { set; get; }
        public string Author { set; get; }
        public int Level { set; get; }
        public int Answer { set; get; }
        public int Summarize { set; get; }
        public DateTime PublishTime { set; get; }
        public ProblemStatus Status { set; get; }
        public IList<KeywordModel> Keywords { set; get; }



    }
}
