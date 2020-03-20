using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    class Problem
    {
        ///求助版块，定义一个类Problem，包含字段：标题（Title）、
        ///正文（Body）、悬赏（Reward）、发布时间（PublishDateTime）
        ///和作者（Author），和方法Publish()

        //Title filed;
        internal string Title { get; set; }

        //Body filed.
        internal string Body { get; set; }

        //Reward filed
        internal int Reward { get; set; }

        //PublishDataTime filed.
        internal string PublishDataTime { get; set; }

        //Author filed..
        internal string Author { get; set; }

        //Publish method
        public void Publish()
        {
            return;
        }



    }
}
