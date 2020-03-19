using System;
using System.Collections.Generic;
using System.Text;

namespace SevenLearnCsharp
{
    public class LogIn
    {

        internal string Title { get; set; }//获得标题方法

        internal string UserName { get; set; }//获得用户名方法

        internal string UserPwd { get; set; }//获得密码方法

        internal string Verification { get; set; }//获得验证码方法


        internal string Getchange { get; set; }//获得刷新验证码方法

        internal bool Submit() //提交按钮，我怎么越写越懵逼了呢
        {
            return true;
        }

        internal bool RememberMe() //记住我，点了就返回true，不点就不生效。
        {
            return true;
        }

    }



}
