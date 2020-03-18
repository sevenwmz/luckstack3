using System;
using System.Collections.Generic;
using System.Text;

namespace SevenLearnCsharp
{
    class Problem
    {
        private string _title;  //作业要求，定义一个problem类，包含标题
        internal string GetTitle { get; set; }//标题获得方法


        private string _body;//正文字段
        internal string GetBody { get; set; }//正文获得方法

        private string _reward;//悬赏字段
        internal string GetReward { get; set; }//悬赏获得方法

        private string _publishDataTime;//发布时间
        internal string GetPublishDataTime { get; set; }//发布时间获得方法

        private string _author;//作者字段
        internal string GetAuthor { get; set; }//作者字段获得方法


        internal Problem publish(Problem publish)
        {
            return publish;
        }

    }
}
