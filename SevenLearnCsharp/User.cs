using System;

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
        private int _invitedBy;//邀请码

        internal string Invitation { get; set; }//获得邀请人方法


        internal int InvitationPwd
        {
            get { return _invitedBy < 4 ? 0 : _invitedBy; }
            set { _invitedBy = value; }
        }//获得邀请码方法

        private string _name;
        private string _admin { set; get; }
        internal string UserName
        {
            get => _name;
            set
            {

                if (_admin == value)
                {
                    Console.WriteLine("系统管理员");
                    User.admin();
                    return;//maby return at here is uesless... cause,last function alreaday move other place.
                }//else nothing!
                _name = value;
            }
        }//获得用户名方法

        static void admin()
        {//admin的功能执行，很简陋的写了个函数，不确定这么写是否对,如果是管理员就跳转到他的。。。。
            //something at here.
        }

        private string _password;


        internal string UserPwd
        {
            set => _password = value;
        }//获得密码方法

        internal string UserPwdAgain { get; set; }//获得确认密码方法

        internal string Verification { get; set; }//获得验证码方法



    }

}
