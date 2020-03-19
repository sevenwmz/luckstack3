using System;
using System.Collections.Generic;
using System.Text;

namespace SevenLearnCsharp
{
    public class HelpMoney
    {

        internal string UserName { get; set; }

        internal string Level { get; set; }


        internal HelpMoney Table(HelpMoney table)
        {//这里是表头的row，不知道是具体是啥，感觉是一堆小的字段组成，但跟感觉是像方法。
            return table;
        }

        internal HelpMoney Body(HelpMoney body) //正文部分，我这里是空的，不知道长啥样，就先写个方法放着。
        {
            return body;
        }


    }
}
