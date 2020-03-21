using System;

namespace Entity
{
    public sealed class User
    {
        #region constructer method


        #region 设计一种方式，保证： 每一个User对象一定有Name和Password赋值
        //public User(string Name, string Password)
        //{
        //    this._userName = Name;
        //    this.Password = Password;
        //}
        #endregion
        public User()
        {

        }
        public User(string parameter)
        {
            _userName = parameter;
        }
        


        #endregion


        #region  Filed and properties
        ///注册/登录功能，定义一个User类，包含字段：Name（用户名）、
        ///Password（密码）和 邀请人（InvitedBy），和方法：Register()、Login()
        ///
        //InvitedBy method
        internal string InvitedBy { get; set; }
        //InvitedBycode char.
        private int InvitedByCode { get; set; }

        //UserName,
        //internal string userName { get; set; }

        #region 2.如果user.Name为“admin”，输入时修改为“系统管理员”( Secend Day )
        private string _userName;
        public string UserName
        {
            set 
            {
                if ("admin" == value)
                {
                    value = "系统管理员";
                    return;
                }
                _userName = value;
            }
            //set { _userName = value == "admin" ? "系统管理员" : value; }
            // i can't understand how wrint like this.  i have to learn more.
            get => _userName;
        }

        #endregion


        //password method
        //internal string Password { get; set; }
        #region 1.user.Password在类的外部只能改不能读( Secend Day )
        public string Password
        {
            set => Password = value;
        }

        #endregion


        //Password confirm.
        internal string PasswordAgain { get; set; }
        //Verification Code
        internal string VerificationCode { get; set; }


        #endregion


        #region Function

        //Register Page.
        public void Register()
        {//写在前面，想了下，获取用户输入传递给后台验证应该是前端的事情，前端提供接口，后台进行验证处理就可以。
         //现在是简单逻辑，很多没有写，比如非法字符，密码过长等。。。
            if (InvitedBy == null)
            {
                Console.WriteLine("没有邀请人");
                return;
            }//else nothing
            if (InvitedByCode < 4)
            {
                Console.WriteLine("邀请码不得小于4位");
                return;
            }//else nothing
            if (UserName == null)
            {
                Console.WriteLine("输入用户名");
                return;
            }//else nothing
            //if (Password == null)
            //{
            //    Console.WriteLine("请输入密码");
            //    return;
            //}//else nothing
            //if (PasswordAgain != Password)
            //{
            //    Console.WriteLine("两次密码不一致");
            //    return;
            //}//else nothing
            if (VerificationCode == null)
            {
                Console.WriteLine("pleas Input VerificationCode at here.");
                return;
            }
            else
            {
                Console.WriteLine("loading.....");
                return;
            }
        }

        //Login Page.
        public void Login()
        {
            if (UserName == null)
            {
                Console.WriteLine("输入用户名");
                return;
            }//else nothing
            //if (Password == null)
            //{
            //    Console.WriteLine("请输入密码");
            //    return;
            //}//else nothing
            if (VerificationCode == null)
            {
                Console.WriteLine("pleas Input VerificationCode at here.");
                return;
            }
            else
            {
                Console.WriteLine("loading.....");
                return;
            }
        }

        

        
        #endregion

    }
}
