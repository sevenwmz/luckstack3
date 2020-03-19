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


        internal string UserName { get; set; }//获得用户名方法

        internal string UserPwd { get; set; }//获得密码方法

        internal string UserPwdAgain { get; set; }//获得确认密码方法

        internal string Verification { get; set; }//获得验证码方法

        internal string change { get; set; }//获得刷新验证码方法


    }

}
