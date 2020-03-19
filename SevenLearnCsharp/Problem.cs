using System;
using System.Collections.Generic;
using System.Text;

namespace SevenLearnCsharp
{
    public class Problem
    {

        internal string Title { get; set; }//标题获得方法


        internal string Body { get; set; }//正文获得方法

        internal string Reward { get; set; }//悬赏获得方法

        internal string PublishDataTime { get; set; }//发布时间获得方法

        internal string Author { get; set; }//作者字段获得方法


        internal Problem publish(Problem publish)
        {
            return publish;
        }

    }
}
