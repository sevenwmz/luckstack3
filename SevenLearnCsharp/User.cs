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
        ///写了一大堆字段后突然想到了一个问题，那就是既然字段都一样，需要获得一个隐私的字段，和配合的方法
        ///既然都需要，那我为什么不直接写一个字段就可以了，每次new新对象使用就可以了。为什么造这么多不同的玩意儿
        ///既然写了，就先这么放着，等胖飞哥查作业的时候问问他。


        private string _title;//注册页面标题
        internal string GetTitle { get; set; }//获得标题方法

        private string _whyInvitation;//为什么需要邀请
        internal string GetWhyInvitation { get; set; }//获得方法

        private string _invitation;//邀请人
        internal string GetInvitation { get; set; }//获得邀请人方法

        private int _invitationPwd;//邀请码
        internal int GetInvitationPwd 
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



        private string _userName;//用户名
        internal string GetUserName { get; set; }//获得用户名方法

        private string _userPwd;//密码
        internal string GetUserPwd { get; set; }//获得密码方法

        private string _userPwdAgain;//确认密码
        internal string GetUserPwdAgain { get; set; }//获得确认密码方法

        private string _verification;//验证码
        internal string GetVerification { get; set; }//获得验证码方法

        private string _change;//刷新验证码
        internal string Getchange { get; set; }//获得刷新验证码方法

        private string _rightSideExplain;//右侧说明栏
        internal string Get_rightSideExplain{ get; set; }//获得右侧说明栏方法

        internal bool Submit() //提交按钮，我怎么越写越懵逼了呢
        {
            return true;
        }

        internal bool Reset() //重置按钮，我怎么越写越懵逼了呢+1
        {
            return true;
        }

        private string _logIn;//小的登录跳转字段
        internal string GetLogIn { get; set; }//获得登录跳转方法

    }

}
