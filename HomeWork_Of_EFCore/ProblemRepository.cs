using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace HomeWork_Of_EFCore
{
    public class ProblemRepository
    {
        //利用Linq to EntityFramework，实现方法：GetBy(IList < ProblemStatus > exclude, bool hasReward, bool descByPublishTime)，该方法可以根据输入参数： 
        //IList<ProblemStatus> exclude：不显示（排除）某些状态的求助
        //bool hasReward：只显示已有酬谢的求助（如果传入值为true的话） 
        //bool descByPublishTime：按发布时间正序还是倒序
        //参考：求助列表（不显示 / 只显示）和文章列表（正序 / 倒序）
        public IList<Problem> GetBy(IList<ProblemStatus> exclude, bool hasReward, bool descByPublishTime)
        {
            IList<Problem> temp = new List<Problem>();
            temp = GetAfterExclude(exclude);

            if (hasReward)
            {
                temp = GetProblemWithout(temp);
            }
            return GetProblemPublishTimeBy(temp, descByPublishTime);
        }
        public IList<Problem> GetAfterExclude(IList<ProblemStatus> exclude)
        {
            IQueryable<Problem> repository = new Repository_Of_EFCore().Problem;
            return repository.Where(p => !exclude.Contains(p.Statu)).ToList();
        }
        public IList<Problem> GetProblemWithout(IList<Problem> problems)
        {
            return problems.Where(p => p.Reward > 0).ToList();
        }
        public IList<Problem> GetProblemPublishTimeBy(IList<Problem> problems, bool descByPublishTime)
        {
            if(descByPublishTime)
            {
                return problems.OrderBy(p => p.PublishTime).ToList();
            }
            return problems.OrderByDescending(p => p.PublishTime).ToList(); 
        }

    }

    public enum ProblemStatus
    {
        [Description("已撤销")]
        cancelled,
        [Description("已酬谢")]
        Rewarded,
        [Description("协助中")]
        inprocess,
        [Description("待协助")]
        assist
    }
}
