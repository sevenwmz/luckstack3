using System;

namespace Entity
{
    public class User
    {


        public User()
        {

        }
        public User(string parameter)
        {

        }
        ///注册/登录功能，定义一个User类，包含字段：Name（用户名）、
        ///Password（密码）和 邀请人（InvitedBy），和方法：Register()、Login()
        ///
        #region 字段放在了一起

        //InvitedBy method
        internal string InvitedBy { get; set; }
        //InvitedBycode char.
        private int InvitedByCode { get; set; }

        //UserName,
        internal string Name { get; set; }
        //password method
        internal string Password { get; set; }
        //Password confirm.
        internal string PasswordAgain { get; set; }
        //Verification Code
        internal string VerificationCode { get; set; }


        #endregion



        //Register Page.
        internal static void Register()
        {//写在前面，想了下，获取用户输入传递给后台验证应该是前端的事情，前端提供接口，后台进行验证处理就可以。
        //现在是简单逻辑，很多没有写，比如非法字符，密码过长等。。。
            if (InvitedBy == null)
            {
                Console.WriteLine("没有邀请人");
                return;
            }//else nothing
            if (InvitedByCode < 4 )
            {
                Console.WriteLine("邀请码不得小于4位");
                return;
            }//else nothing
            if (Name == null)
            {
                Console.WriteLine("输入用户名");
                return;
            }//else nothing
            if (Password == null)
            {
                Console.WriteLine("请输入密码");
                return;
            }//else nothing
            if (PasswordAgain != Password)
            {
                Console.WriteLine("两次密码不一致");
                return;
            }//else nothing
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
        internal static void Login()
        {
            if (Name == null)
            {
                Console.WriteLine("输入用户名");
                return;
            }//else nothing
            if (Password == null)
            {
                Console.WriteLine("请输入密码");
                return;
            }//else nothing
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
    }
}
