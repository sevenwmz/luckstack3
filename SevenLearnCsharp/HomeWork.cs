using System;

namespace SevenLearnCsharp
{
    class HomeWork
    {

        static void Main(string[] args)
        {
            //int[] w = { 1, 45, 23, 64, 75, 34 };
            //int find = 3;
            //bool fond = false;
            //for (int i = 0; i < w.Length; i++)
            //{
            //    if (w[i] == find)
            //    {
            //        fond =  true;
            //        break;
            //    }

            //}
            //if (!fond)
            //{
            //    Console.WriteLine("没找到");
            //}
            //Console.WriteLine();




            //int max = 0;
            //for (int i = 0; i < some.Length; i++)
            //{

            //    if (max < some[i])
            //    {
            //        max = some[i];
            //    }//else nothing
            //}
            //Console.WriteLine("max="+max);


            //#region 2020.3.10 
            /////第一题
            /////http://17bang.ren/Article/438
            /////分别用for循环和while循环输出：1,2,3,4,5 和 1,3,5,7,9
            /////


            //for (int i = 1; i < 6; i++)
            //{
            //    Console.WriteLine("here is for 'for' 1 to 5 Program"+i);
            //}
            //Console.WriteLine("----------------");
            //for (int i = 1; i < 10; i += 2)
            //{
            //    Console.WriteLine("here is for 'for' 1 to 9 Program" + i);
            //}
            //Console.WriteLine("-----------------");
            //int j  = 1;
            //int k = 1;
            //while (j < 6)
            //{

            //    Console.WriteLine("here is for 'while' 1 to 5 Program" + j);
            //    j++;
            //}
            //Console.WriteLine("-----------------");
            //while (k<10)
            //{

            //    Console.WriteLine("here is for 'while' 1 to 9 Program" + k);
            //    k += 2;
            //}


            //#endregion

            //#region 第二题
            /////用for循环输出存储在一维/二维数组里的源栈所有同学姓名/昵称

            //string[,] name = { { "王明智", "刘江平", "李腾", "赵淼", "小黄", }, { "SEVEN", "川流不息", "陌尘", "推理", "ASP黄" } };

            //for (int i = 0; i < name.GetLength(1)-1; i++)
            //{
            //    Console.WriteLine($"第{i}个同学的姓名是{name[0,i]}他的花名是{name[1,i]}");
            //}

            ////#endregion

            //#region 第三题
            ////让电脑计算并输出：99 + 97 + 95 + 93 + ...+1的值
            //int sum = 0;
            //for (int i = 99; i > 0; i-=2)
            //{
            //    sum += i;
            //}
            //Console.WriteLine(sum);
            ////这个题有点点难，偷偷百度了下怎么写。一直的误区在于把所有内容写在了for里面，虽然感觉到了不妥，但是没有太清晰的思路
            ///感觉怎么被赋值的下一次都会被清零。生气。不过理解的也更多了，脸红！！！
            //#endregion


            //#region 第四题
            ////将源栈同学的成绩存入一个double数组中，用循环一次性地找到最高分和最低分
            //double[] score = { 17, 52, 13, 57, 54, 96, 41, 32 };

            //double max = score[0];
            //double min = score[0];
            //for (int i =1; i < score.Length; i++)
            //{
            //    //17 < 52
            //    if (max < score[i])
            //    {
            //        max = score[i];
            //    }
            //    // 17 > 52
            //    else if (min > score[i] )
            //    {
            //        min = score[i];
            //    }

            //}
            //Console.WriteLine($"max={max},min={min}");
            //Console.WriteLine();
            ///最新消息，我搞定这个题了，原来少了东西，是我应该被打。。。生气，和自己生气。

            //不行了，这个题彻底把我搞懵了，
            ///我先空着，为什么max小于i 对其重新赋值不可以呢？反而是小
            //#endregion

            //#region 第五题
            ////设立并显示一个二维数组的值，元素值等于下标之和。

            int[,] number = { { 0, 1, 2, 3 }, { 1, 2, 3, 4 }, { 2, 3, 4, 5 } };

            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Console.Write(number[0, j] + " ");
                    }
                }
                else if (i == 1)
                {
                    Console.WriteLine();
                    for (int k = 0; k < 4; k++)
                    {
                        Console.Write(number[1, k] + " ");
                    }
                }
                else if (i == 2)
                {
                    Console.WriteLine();
                    for (int l = 0; l < 4; l++)
                    {
                        Console.Write(number[2, l] + " ");
                    }

                }
            }
            ///看我闭眼瞎写


            //#endregion


            #region 第六题
            //找到100以内的所有质数（只能被1和它自己整除的数）
            ///先把100以内的数字放入一个数组
            ///然后用循环从1开始除，一直循环到他本身，如果余数为1就装入另一个数组里。
            ///




            #endregion

            #region 第七题
            //生成一个元素（值随机）从小到大排列的数组并输出
            //int[] receive = new int[10];

            ////这里是问二期大佬们怎么操作生成的一堆随机数，实在想不出来
            //for (int i = 0; i < receive.Length; i++)
            //{
            //    receive[i] = new Random().Next(1000); 
            //}


            ////这里是直接把冒泡背下来，套公式写的冒泡排序。。。
            //for (int i = 0; i < receive.Length -1; i++)
            //{
            //    for (int j = 0; j < receive.Length-1-i; j++)
            //    {
            //        if (receive[j] < receive[j+1])
            //        {
            //            int temp = 0;
            //            temp = receive[j];
            //            receive[j] = receive[j + 1];
            //            receive[j + 1] = temp;
            //        }
            //    }
            //}

            //for (int i = 0; i < receive.Length; i++)
            //{
            //    Console.Write(receive[i]+",");
            //}
            #endregion


            #region 第八题
            //猜数字游戏
            //系统生成一个谜底数字：1000以内的随机数
            //系统将用户输入的猜测值和谜底进行比较，给出：“太大 / 太小 / 猜中”的提示
            //如果用户在5次以内猜中，提示：太棒了
            //8次：不错
            //10次以内：过关
            ////= 10次：游戏结束，未能过关
            //int guess = new Random().Next(0, 999);
            //Console.WriteLine(guess);
            //for (int i = 0; i < 11; i++)
            //{
            //    int input = Convert.ToInt32(Console.ReadLine());
            //    if (guess > input)
            //    {
            //        Console.WriteLine("小了");
            //    }
            //    else if (guess < input)
            //    {
            //        Console.WriteLine("大了");
            //    }
            //    else if(guess == input)
            //    {
            //        Console.WriteLine("猜中");
            //        if (input == guess && i <= 5)
            //        {
            //            Console.WriteLine("太棒了");
            //            break;
            //        }
            //        else if (input == guess && i <= 8)
            //        {
            //            Console.WriteLine("不错");
            //            break;
            //        }
            //        else if (input == guess && i <= 10)
            //        {
            //            Console.WriteLine("过关");
            //            break;
            //        }

            //    }
            //    else if (i == 10)
            //    {
            //        Console.WriteLine("游戏结束，未能过关");
            //    }


            //}


            #endregion








            //// make a number group
            //int[] array = { 23, 21, 54, 234, 75, 2346, 74, 231, 642, 35, 43, 43 };


            //int temp = 0;
            //for (int i = 0; i < array.Length-1; i++)
            //{
            //    for (int j = 0; j < array.Length - 1-i; j++)
            //    {
            //        if (array[j] > array[j + 1])
            //        {
            //            temp = array[j + 1];
            //            array[j + 1] = array[j];
            //            array[j] = temp;

            //        }

            //    }
            //}

            //Console.Write(array);




            ////作业：

            ////将源栈同学姓名 / 昵称分别：
            ////按进栈时间装入一维数组，
            ////按座位装入二维数组，
            ////并输出共有多少名同学。

            //string[,] OtherTeste = { { "王明智", "刘江平", "李腾", "赵淼", "小黄", }, { "2月17", "2月17", "2月18", "2月17", "2月20" } };


            //for (int i = 1; i < OtherTeste.GetLength(1); i++)
            //{

            //        Console.WriteLine($"第{i}个同学是{OtherTeste[0,i]},入栈时间是{OtherTeste[1,i]}");

            //}

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
            //string verificationcode = "wybz";
            //string username = "飞哥最胖";
            //Random random = new Random();
            //int password = random.Next(1000, 9999);

            //Console.WriteLine("请输入验证码（wybz）");
            //Console.WriteLine("提示，王月半子的缩写！！！你一共有三次机会输入！！");
            //Console.WriteLine("王月半子出品，必属精品！！！");
            ////到这里为止
            //for (int i = 1; i < 4; i++)
            //{
            //    string getinput = Console.ReadLine();
            //    if (getinput == verificationcode)
            //    {
            //        Console.WriteLine("验证码验证中......");
            //        Console.WriteLine("验证成功，请在下方输入用户名：");
            //        Console.WriteLine("请输入用户名（飞哥最胖）");
            //        string input = Console.ReadLine();
            //        if (username == input)
            //        {
            //            Console.WriteLine("用户名验证中......");
            //            Console.WriteLine("用户名验证成功，请在下方输入密码：");
            //            Console.WriteLine("请输入密码（提示：4位数，你有12次机会输入：）");

            //            for (int x = 1; i < 12; i++)
            //            {
            //                int get = Convert.ToInt32(Console.ReadLine());
            //                if (password == get)
            //                {
            //                    Console.WriteLine("密码验证中......");
            //                    Console.WriteLine("密码验证成功，load in......：");
            //                    Console.WriteLine("*恭喜！登录成功");
            //                    break;
            //                }
            //                else if (get > password)
            //                {
            //                    Console.WriteLine("忘记密码了？输入有误，提示：大了！");
            //                    Console.WriteLine($"这是你的第{x}次机会");
            //                }
            //                else if (password > get)
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


        static int TwoPointSearch(int[] array,int Key) 
        {
            int left = 0, right = array.Length - 1;

            while (left <= right)
            {

                int middle = (left + right) / 2;
                if (Key == array[middle])
                {
                    int result = middle;
                    Console.WriteLine(array[middle]); //找到查找数字
                    return middle;
                }
                else
                {
                    if (array[middle] > Key)
                    {
                        right = middle - 1;
                    }
                    else if (array[middle] < Key)
                    {
                        left = middle + 1;
                    }
                }
            }
            Console.WriteLine("没有这个数字");
            return -1;// 查找失败
        }



        /// <summary>
        /// 冒泡排序，直接传递数组或者数字就可以。
        /// </summary>
        /// <param name="array"></param>
        static void BubbleSort(params int[] array)
        {
            int temp = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {

                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }

                }
            }
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + ",");
            }

        }
    }
}
