using System;

namespace SevenLearnCsharp
{
    class HomeWork
    {


        static void Main(string[] args)
        {

            

            int[] tests = { 54, 1, 13, 23, 45, 55, 67, 87, 97, 123, 234, };


            ///读取数组，用第一个开始比对，从右到左。如果遇到小的就换位置，把小的放到他的左面。
            ///然后就是左开始比对，遇到比他大的就放到右面。一直循环
            ///首先需要确定第一个数组下标，是teste【i】
            ///然后需要从数组的最后一个数组开始遍历
            ///这里需要一个for循环
            ///找到后做if判断，如果比当前数小，swap一下，
            ///现在移动下标，从左面开始查找，这个怎么移动呢目前想到的用另一个for循环，或者if判断？在if里面做循环？
            ///

            //int left = tests[0],right = tests.Length-1;
            //if (left <= right)
            //{
            //    return
            //}
            //for (int i = 0; i < tests.Length; i++)
            //{
            //    if (tests[i] >)
            //    {
            //        Swap(ref tests[i], ref tests[-i]);
            //    }
            //}



            #region 第六题
            //找到100以内的所有质数（只能被1和它自己整除的数）
            ///先把100以内的数字放入一个数组
            ///然后用循环从1开始除，一直循环到他本身，如果余数为1就装入另一个数组里。
            ///


            ///3.13 最新消息，表示依然懵懵懂懂，不会做

            #endregion
        }




        /// <summary>
        /// 快速排序
        /// </summary>
        /// <param name="array">输入一个数组</param>
        /// <param name="left">数组中的第一个下标</param>
        /// <param name="right">数组中的最后一个下标</param>
        static void FastSort(int[] array, int left, int right)
        {///写在前面的，这是抄过来的一种方法，理解起来有一些小困难，但是主要部分都看懂了。现在自己能写出来
         ///不过三分靠理解，七分靠记忆。轮子已有，常来熟悉，只求面试别坑。
            if (left >= right) return;
            int Index = FastSortBody(array, left, right);
            FastSort(array, left, Index - 1);
            FastSort(array, Index + 1, right);
        }
        /// <summary>
        /// 私有方法，服务于fastsort
        /// </summary>
        /// <param name="array">上个数组中传递</param>
        /// <param name="left">获得第一个下标位置</param>
        /// <param name="right">获得右边下标位置</param>
        /// <returns></returns>
        static int FastSortBody(int[] array, int left, int right)
        {///应该算是，提前知道了private的作用，和public的功能.先不写，等讲了在写。
            int center = array[left], i = left, j = right;
            while (left < right)
            {
                while (array[right] >= center && i < j)
                {
                    j--;
                    array[i] = array[j];
                }
                while (array[right] >= center && i < j)
                {
                    i++;
                    array[j] = array[i];
                }
            }
            array[i] = center;
            return i;
        }

        //static bool LogOn(string input,out string result)
        //{

        //    input = Console.ReadLine();
        //    result = input;
        //    if (input)
        //    {
        //        ///登录
        //    }
        //    else
        //    {
        //        result;
        //    }
        //    return input;
        //}




        /// <summary>
        /// 作业输出加减乘除
        /// </summary>
        /// <param name="a">第一个数字</param>
        /// <param name="b">第二个数字</param>
        static void Count(double a, double b)
        {
            ///1.输出两个整数 / 小数的和 / 差 / 积 / 商
            ///

            Console.WriteLine(a + b);
            Console.WriteLine(a - b);
            Console.WriteLine(a * b);
            Console.WriteLine(a / b);


            ///输出两个小数的和/差/积/商
            ///
            Console.WriteLine(a + b);
            Console.WriteLine(a - b);
            Console.WriteLine(a * b);
            Console.WriteLine(a / b);
        }



        /// <summary>
        /// 登录系统
        /// </summary>
        static void LogOn()
        {
            /// ThirdDay HomeWork.
            /// 观察一起帮登录页面，用if...else...完成以下功能。
            ///  用户依次由控制台输入：验证码、用户名和密码：
            /// 如果验证码输入错误，直接输出：“*验证码错误”；
            ///  如果用户名不存在，直接输出：“*用户名不存在”；
            /// 如果用户名或密码错误，输出：“*用户名或密码错误”
            /// 以上全部正确无误，输出：“恭喜！登录成功！”
            ///PS：验证码 / 用户名 / 密码直接预设在源代码中，输入由Console.ReadLine()完成。
            ///
            bool key = true;
            string verificationcode = "wybz", username = "飞哥最胖", password = "123456";
            Console.WriteLine("请输入验证码（wybz）");
            string getinput = Console.ReadLine();
            if (getinput != verificationcode)
            {
                Console.WriteLine("输入错误");
                return;
            }//else nothing

            Console.WriteLine("请输入用户名（飞哥最胖）");
            string input = Console.ReadLine();
            if (input != username)
            {
                Console.WriteLine("*用户名不存在");
                return;

            }//else nothing
            
            Console.WriteLine("请在下方输入密码：(123456)");
            string get = Console.ReadLine();
            if (get != password)
            {
                Console.WriteLine("用户名或密码错误");
                return;
            }
            else
            {
                Console.WriteLine("恭喜！登录成功！"+key);
                return;
            }///写在最后，竟然没做出来那个return key. 打脸啊打脸 ---ψ(╰_╯)---

        }

        /// <summary>
        /// 这个只是封装作业，没什么意义
        /// </summary>
        static void TriningForAndWhile()
        {
            /////第一题
            /////http://17bang.ren/Article/438
            /////分别用for循环和while循环输出：1,2,3,4,5 和 1,3,5,7,9
            /////

            for (int i = 1; i < 6; i++)
            {
                Console.WriteLine("here is for 'for' 1 to 5 Program---" + i);
            }
            Console.WriteLine("----------------");
            for (int i = 1; i < 10; i += 2)
            {
                Console.WriteLine("here is for 'for' 1 to 9 Program----" + i);
            }
            Console.WriteLine("-----------------");
            int j = 1;
            int k = 1;
            while (j < 6)
            {

                Console.WriteLine("here is for 'while' 1 to 5 Program---" + j);
                j++;
            }
            Console.WriteLine("-----------------");
            while (k < 10)
            {

                Console.WriteLine("here is for 'while' 1 to 9 Program---" + k);
                k += 2;
            }
        }



        /// <summary>
        /// 输入0-99的相加
        /// </summary>
        /// <param name="number">需要相加的一个数值</param>
        /// <returns></returns>
        static int Sum(int number)
        {
            int result = number;
            int sum = 0;
            for (int i = 0; i < number; i += 2)
            {
                sum += i;
            }
            Console.WriteLine(sum);
            return sum;
        }



        /// <summary>
        /// 输出二维名字循环
        /// </summary>
        /// <param name="array">输入一个string类型的二维数组</param>
        static void NameAndData(string[,] array)
        {
            for (int i = 0; i < array.GetLength(1); i++)
            {
                Console.WriteLine($"第{i}个同学是{array[0, i]},入栈时间是{array[1, i]}");
            }///实在想不出来return应该写在哪儿，尝试过写在外面。但是不行,需要返回二维数组
        }



        /// <summary>
        /// 输出一个循环二维数组
        /// </summary>
        /// <param name="array">需要一个数组的长度</param>
        /// <returns></returns>
        static int[,] CycleArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = i + j;
                }
                Console.WriteLine();
            }

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
            return array;
        }



        /// <summary>
        /// 获取一个平均数，输入一个数组
        /// </summary>
        /// <param name="array">参数需要一个数组</param>
        /// <returns></returns>
        static double[] GetAverage(params double[] array)
        {
            double sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum = sum + array[i];
            }
            double scores = Math.Round((sum / array.Length), 4);
            Console.WriteLine(scores);
            return array;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="result">输入out double result就可以，这里只是多一个返回值</param>
        /// <param name="array">直接输入一个数组就好</param>
        /// <returns></returns>
        static double GetMaxAndMin(out double result, params double[] array)
        {
            double max = array[0];
            double min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (max < array[i])
                {
                    max = array[i];
                }
                else if (min > array[i])
                {
                    min = array[i];
                }
            }
            Console.WriteLine("Max : " + max);
            Console.WriteLine("Min : " + min);
            result = min;
            return max;///return只能return一个，min return不了，这个未解之谜等待飞哥。如果无解，我就考虑在写一次求最小了
        }



        /// <summary>
        /// 获得一组随机数，并对其排序
        /// </summary>
        /// <param name="Key">输入要获得随机数的个数 例：3，获得3个随机数</param>
        /// <returns></returns>
        static int GetRandomNumber(int Key)
        {
            int[] receive = new int[Key];

            for (int i = 0; i < receive.Length; i++)
            {
                receive[i] = new Random().Next(1000);
            }
            for (int i = 0; i < receive.Length; i++)
            {

                Console.Write(receive[i] + ",");
            }
            Console.WriteLine();
            Console.WriteLine("下面是排序后的随机数");
            BubbleSort(receive);
            return receive[Key - 1];

        }



        /// <summary>
        /// 猜数字游戏，直接运行，无需参数。
        /// </summary>
        static void GuessMe()
        {
            Console.WriteLine("欢迎来到猜数字游戏");
            Console.WriteLine("你有十次机会猜中它，如果猜不中。飞哥，网线，打，懂？");
            int guess = new Random().Next(0, 999);
            for (int i = 0; i < 10; i++)
            {
                int input = Convert.ToInt32(Console.ReadLine());
                if (i == 9)
                {
                    Console.WriteLine("(～￣(OO)￣)ブ");
                    Console.WriteLine("游戏结束，未能过关");
                }//else nothing

                /// Here is method main.
                if (input == guess)
                {
                    Console.WriteLine("猜中");
                    if (i < 5)
                    {
                        Console.WriteLine("你真牛逼！");
                        return;
                    }
                    else if (i < 8)
                    {
                        Console.WriteLine("不错嘛！");
                        return; 
                    }
                    else
                    {
                        Console.WriteLine("过关");
                        return;
                    }
                }
                else if (guess > input)
                {
                    Console.WriteLine("小了");
                }
                else
                {
                    Console.WriteLine("大了");
                }
            }
        }



        /// <summary>
        /// 查找数组中的最大数值
        /// </summary>
        /// <param name="array">需要先传入一个数组</param>
        /// <param name="Key">在传入一个需要查找的值</param>
        /// <returns></returns>
        static int FindMax(int[] array, int Key)
        {
            bool fond = false;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] == Key)
                {
                    fond = true;
                    return array[i];
                }
            }
            if (!fond)
            {
                Console.WriteLine("没找到");
                return -1;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 交换方法
        /// </summary>
        /// <param name="a">需要ref 引用参数a</param>
        /// <param name="b">需要ref 引用参数b</param>
        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }


        /// <summary>
        /// 二分查找
        /// </summary>
        /// <param name="array">输入一个已经排好了的数组</param>
        /// <param name="Key">输入要查找的数字</param>
        /// <returns></returns>
        static int BinarySeek(int[] array, int Key)
        {
            int left = 0, right = array.Length - 1, result = 0;
            while (left <= right)
            {
                int middle = (left + right) / 2;
                if (Key == array[middle])
                {
                    //result = middle;///直接想不通怎么直接输出的是我要找的数字，而不是下标
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
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
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
