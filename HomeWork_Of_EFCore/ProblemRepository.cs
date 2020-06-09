using System;
using System.Collections.Generic;
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
        public void GetBy(IList<ProblemStatus> exclude, bool hasReward, bool descByPublishTime)
        {

        }

    }

    public enum ProblemStatus
    {
        hasReward = 1,
        PublishTime = 2,
    }
}
