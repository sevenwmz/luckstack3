using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Problem
{
    public class ProblemIndexModel
    {
        public int SumOfProblem { set; get; }
        public ProblemPageChoose Status { set; get; }
        public IList<ProblemItemModel> Items { set; get; }
    }

    public enum ProblemPageChoose
    {
        cancelled,
        Rewarded,
        inprocess,
        assist
    }

}
