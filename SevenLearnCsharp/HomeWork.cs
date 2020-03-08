using System;

namespace SevenLearnCsharp
{
    class HomeWork
    {
        static void Main(string[] args)
        {
            ///  FristDay：作业
            ///  
            ///观察一起帮个人资料页面，用合适的变量类型存储页面用户输入信息，并解释为什么。
            ///
            ///头像部分上传的图片没想好用什么储存？？？目前已知存储类型
            ///string int float double dicenme。。。
            ///
            ///关键字旁边的输入框 和下方的自我介绍，应选择（string ）字符串进行存储
            ///因为用户在输入中可能会用到英文、数字、标点符号或中文等情况。
            //For 关键字
            //string KeyWord = Console.ReadLine();
            ////For 自我介绍
            //string SelfDescription = Console.ReadLine();

            ///// SecondDay：作业
            ///// 
            /////1.输出两个整数/小数的和/差/积/商
            /////
            //Console.WriteLine("请输入任意2个整数，系统将会运算出这两个整数的和/差/积/商！");
            //int IntFristInput = Convert.ToInt32(Console.ReadLine());
            //int IntSecondInput = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine("----------这里是分割线----------");
            //Console.WriteLine(IntFristInput + IntSecondInput);
            //Console.WriteLine(IntFristInput - IntSecondInput);
            //Console.WriteLine(IntFristInput * IntSecondInput);
            //Console.WriteLine(IntFristInput / IntSecondInput);


            /////输出两个小数的和/差/积/商
            /////
            //Console.WriteLine("现在是浮点数时间..");
            //Console.WriteLine("zhe请输入任意2个小数，系统将会运算出这两个整数的和/差/积/商！");
            //double FloatFristInput = Convert.ToDouble(Console.ReadLine());
            //double FloatSecondInput = Convert.ToDouble(Console.ReadLine());

            //Console.WriteLine(FloatFristInput + FloatSecondInput);
            //Console.WriteLine(FloatFristInput - FloatSecondInput);
            //Console.WriteLine(FloatFristInput * FloatSecondInput);
            //Console.WriteLine(FloatFristInput / FloatSecondInput);


            /////2.电脑计算并输出：[(23+7)x12-8]÷6的小数值（挑战：精确到小数点以后2位）
            /////这种题目怎么会难道到我？
            /////
            //double Count = ((23 + 7) * 12 - 8) / 6;
            //string Result = Count.ToString("#0.00");
            //Console.WriteLine(Result);

            /////好了，我猜飞哥是不是要搞一个到后面多少位数的任务，还要求四舍五入的那种？
            /////抱歉，我先写好了
            /////往下看！！！
            //double OtherCount = ((23 + 7) * 12 - 8) / 6;
            //string OtherResult = OtherCount.ToString("f20");
            //Console.WriteLine(OtherResult);

            ///3.想一想以下语句输出的结果：
            //int i = 15;
            //Console.WriteLine(i++);
            //i -= 5;
            //Console.WriteLine(i);
            //Console.WriteLine(i >= 10);

            //Console.WriteLine("i值的最终结果为：" + i);

            //int j = 20;
            //Console.WriteLine($"{i}+{j}={i + j}");
            ///肉眼调试竟然错了，让我大吃一惊！！！
            ///"i值的最终结果为：" 这个地方竟然是坑，自动带入了计算后的数字！！！
            ///

            ///4.想一想如下代码的结果是什么，并说明原因：
            //int a = 10;
            //Console.WriteLine(a > 9 && (!(a < 11) || a > 10));
            /// 答案为True左边等式很好理解，
            /// 右边等式先看a小于11是True，但是取反就是false
            /// 第二个a并不大与10，那么就是false
            /// 左边true 且 右边false
            /// 答案true
            /// 顺路鄙视下，你让我掉了一根头发
            /// 

            ///5.当a为何值时，结果为true？
            ///
            //int a = 10;//或者12
            //bool result = (a + 3 > 12) && a < 3.14 * 4 && a != 11;
            //Console.WriteLine(result);

            /// ThirdDay HomeWork.
            /// 观察一起帮登录页面，用if...else...完成以下功能。
            ///  用户依次由控制台输入：验证码、用户名和密码：
            /// 如果验证码输入错误，直接输出：“*验证码错误”；
            ///  如果用户名不存在，直接输出：“*用户名不存在”；
            /// 如果用户名或密码错误，输出：“*用户名或密码错误”
            /// 以上全部正确无误，输出：“恭喜！登录成功！”
            ///PS：验证码 / 用户名 / 密码直接预设在源代码中，输入由Console.ReadLine()完成。
            ///

            //这里面的代码不许动
            //string VerificationCode = "wybz";
            //string UserName = "飞哥最胖";
            //Random random = new Random();
            //int Password = random.Next(1000,9999);
            //Console.WriteLine("请输入验证码（wybz）");
            //Console.WriteLine("提示，王月半子的缩写！！！你一共有三次机会输入！！");
            //Console.WriteLine("王月半子出品，必属精品！！！");
            ////到这里为止
            //for (int i = 1; i < 4; i++) 
            //{
            //    string GetInput = Console.ReadLine();
            //    if (GetInput == VerificationCode)
            //    {
            //        Console.WriteLine("验证码验证中......");
            //        Console.WriteLine("验证成功，请在下方输入用户名：");
            //        Console.WriteLine("请输入用户名（飞哥最胖）");
            //        string Input = Console.ReadLine();
            //        if (UserName == Input)
            //        {
            //            Console.WriteLine("用户名验证中......");
            //            Console.WriteLine("用户名验证成功，请在下方输入密码：");
            //            Console.WriteLine("请输入密码（提示：4位数，你有12次机会输入：）");

            //            for (int x = 1; i < 12; i++)
            //            {
            //                int Get = Convert.ToInt32(Console.ReadLine());
            //                if (Password == Get)
            //                {
            //                    Console.WriteLine("密码验证中......");
            //                    Console.WriteLine("密码验证成功，Load in......：");
            //                    Console.WriteLine("*恭喜！登录成功");
            //                    break;
            //                }
            //                else if (Get > Password)
            //                {
            //                    Console.WriteLine("忘记密码了？输入有误，提示：大了！");
            //                    Console.WriteLine($"这是你的第{x}次机会");
            //                }
            //                else if (Password > Get)
            //                {
            //                    Console.WriteLine("忘记密码了？输入有误，提示：小了！");
            //                    Console.WriteLine($"这是你的第{i}次机会");
            //                }
            //                else
            //                {
            //                    Console.WriteLine("你输入的是什么玩意儿？好好写");
            //                }
            //            }

            //        }
            //        else
            //        {
            //            Console.WriteLine("*用户名不存在");
            //        }
            //    }

            //    else
            //    {
            //        Console.WriteLine("*验证码错误");
            //        Console.WriteLine($"这你都输入错了？这是你的第{i}次机会,看清楚了，wybz，王月半子的缩写");
                   
            //    }
            //}

            
            
            
            
            

            
            

        }
    }
}
