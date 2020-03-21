using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class HelpMoney
    {
        internal string UserName { get; set; }

        internal string Level { get; set; }

        internal string DataTime { get; set; }
        internal int LeftUse { get; set; }
        internal int Freeze { get; set; }
        internal string Type { get; set; }
        internal string Change { get; set; }
        internal string Remarks { get; set; }

        //这个页面里面的那些数据不知道怎么写，这个需要后台传递过来的，方法只能写个空的
        //感觉每一个字段都需要接口传入的
        public void BodyShow()
        {
            return;
        }


    }
}
