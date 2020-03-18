using System;
using System.Collections.Generic;
using System.Text;

namespace SevenLearnCsharp
{
    class LogIn
    {
        private string _title;//注册页面标题
        internal string GetTitle { get; set; }//获得标题方法

        private string _userName;//用户名
        internal string GetUserName { get; set; }//获得用户名方法

        private string _userPwd;//密码
        internal string GetUserPwd { get; set; }//获得密码方法

        private string _verification;//验证码
        internal string GetVerification { get; set; }//获得验证码方法

        private string _change;//刷新验证码
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
