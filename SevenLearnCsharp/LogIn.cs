using System;
using System.Collections.Generic;
using System.Text;

namespace SevenLearnCsharp
{
    public class LogIn
    {
        private string _userPwd;
        private int _verification;

        internal string UserName { get; set; }//获得用户名方法

        internal string UserPwd 
        {
            set { _userPwd = value; } 
        }//获得密码方法

        internal int Verification 
        {
            get { return _verification; }
            set 
            {
                Random random = new Random();
                int randomName = random.Next(1000,9999);
                Console.WriteLine(randomName);
                _verification = randomName;
            } 
        }//获得验证码方法


        public void SignIn()
        {
            if (UserName != "王月半子")
            {
                Console.WriteLine("输入错误");
                return;
            }// else nothing
            if (_userPwd != "wangpz")
            {
                Console.WriteLine("密码输入错误");
                return;
            }
            if (_verification != Verification)
            {//这里的细节需要仔细思考下，verification究竟是前端干的事情还是我干的，在用户输入前就显示验证码
                Console.WriteLine("请刷新");
                return;//按照道理这里应该是一个循环，刷新知道验证码和输入一致后通过，先用return代替。等下在慢慢写、。
            }
            else
            {
                Console.WriteLine("loading.....");
                return;//登录成功
            }
        }


    }



}
