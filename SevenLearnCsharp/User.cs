using System;
using System.Collections.Generic;
using System.Text;

namespace SevenLearnCsharp
{
    public class User
    {
        public User()
        {

        }
        public User(string name)
        {

        }

        internal string Title { get; set; }//获得标题方法
        internal string Invitation { get; set; }//获得邀请人方法

        private int _invitationPwd;//邀请码


        internal int InvitationPwd
        {
            get
            {
                if (_invitationPwd < 4)
                {
                    return 0;
                }
                else
                {
                    return _invitationPwd;
                }
            }
            set { _invitationPwd = value; }
        }//获得邀请码方法

        private string _userName;
        private string _admin { set; get; } 
        internal string UserName
        {
            get => _userName;
            set
            {
                
                if (_admin == value)
                {
                    Console.WriteLine("系统管理员");
                    User.admin();
                    return;//maby return at here is uesless... cause,last function alreaday move other place.
                }
                _userName = value;
            }
        }//获得用户名方法

        static void admin() //admin的功能执行，很简陋的写了个函数，不确定这么写是否对
        {
            //something at here.
        }

        private string _password;
        

        internal string UserPwd
        {
            set { _password = value; }
        }//获得密码方法

        internal string UserPwdAgain { get; set; }//获得确认密码方法

        internal string Verification { get; set; }//获得验证码方法

        internal string change { get; set; }//获得刷新验证码方法


    }

}
