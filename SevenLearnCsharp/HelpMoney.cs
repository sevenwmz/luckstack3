using System;
using System.Collections.Generic;
using System.Text;

namespace SevenLearnCsharp
{
    public class HelpMoney
    {

        internal string UserName { get; set; }

        internal string Level { get; set; }

        private string _dataTime;//以下是表格行内需要的东西
        private int _leftUse;
        private int _freeze;
        private string _type;
        private string _change;
        private string _remarks;

        internal void BodyShow() //表格显示正文部分，目前会写的就这么多。
        {
            new HelpMoney 
            {
                _dataTime = "这里是系统传入" ,
                _leftUse = 0,
                _freeze = 0,
                _type = "这里是系统传入",
                _change = "这里是系统传入",
                _remarks = "这里是系统传入"
            };
            //然后要有一个调用的过程，巴拉巴拉不会写了。
            return;
        }

        
    }
}
