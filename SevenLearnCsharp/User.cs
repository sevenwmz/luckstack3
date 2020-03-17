using System;
using System.Collections.Generic;
using System.Text;

namespace SevenLearnCsharp
{
    public class User
    {
        public User( string name)
        {
            this.name = name;
        }
        public User()
        {

        }
        internal void Agree(ref User user)
        {
            user = new User();
            user.agreecount++;
        }
        public int agreecount;


        public string name;//用户登录

        internal string UserName;//输入用户名提示
        public string GetUserName()
        {//获得用户名的方法，提交返回到后台？数据库
            return "";
        }

        internal string PassWord;
        public string GetPassWord()
        {//想了一下，这个应该要用string，因为会有字母的情况，int不可以
            return "";
        }

        internal string Verification;//验证码字段
        public string GetVerification()
        {//验证码输入框，会有英文的情况发生
            return "";
        }

        public string Touch;//默认提示，输入框显示

        public bool Submit()
        {//提交按钮，如果点了就返回true，没点就是false。
            return true;
        }

        public bool RememberMe() 
        {//记住我单选框，勾选返回后台就是true。
            return true;
        }

        internal string Tips;
        internal string Register;

        public string[] Explain(string[] explain)
        {
            return explain;
        }


    }

}
