using System;
using System.Collections.Generic;
using System.Text;

namespace SevenLearnCsharp
{
    class HelpMoney
    {
        private string _userName;  //用户名，是可变的
        internal string GetUserName { get; set; }

        private string _level;//用户等级，是可变的
        internal string GetLevel { get; set; }

        private string _title = "的";//用户名那一排中间的字，固定是“的”。
        internal string GetTitle(string word)//用户名那一排中间的字，必要时可以替换。
        {
            _title = word;
            return _title;
        }
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
