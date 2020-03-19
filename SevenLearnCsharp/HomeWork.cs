using System;
//using User;
using Entity;
//using SevenLearnCsharp;


namespace SevenLearnCsharp
{
    class HomeWork
    {

        internal int ValuePass(int value)//值的值传递
        {
            ++value;
            Console.WriteLine(value);
            return value;
        }
        internal int ReferencePass(ref int value)//值的引用传递
        {
            ++value;
            Console.WriteLine(value);
            return value;
        }

        internal string _name;
        internal static void ChangeName(HomeWork person) //引用类型的值传递
        {
            person = new HomeWork();
            person._name = "和飞哥一样帅";
            Console.WriteLine(person._name);
        }
        internal static void ChangeingName(ref HomeWork person)//引用类型的引用传递
        {
            person = new HomeWork();
            person._name = "和飞哥一样帅";
            Console.WriteLine(person._name);
        }


        //private static (string, string[], int, int) load()
        //{
        //    var user = (name"wpz", 25);
        //    Console.WriteLine(user.Item1);
        //    return ("", new string[] { " ", " " }, 20, 20);
        //}



        /// <summary>
        /// 创造一个随机数组
        /// </summary>
        /// <param name="length">数组长度</param>
        /// <returns></returns>
        private static int[] getArray(int length = 10)
        {
            int min = 1;
            int[] array = new int[length];//这一步上卡了很久，不知道怎么把length赋值到array数组的长度里
            array[0] = min;//最新消息，上面卡了很久的那步是忘了，看其他作业之前写过，捂脸。。。
            for (int i = 1; i < array.Length; i++)
            {
                Random random = new Random();
                int gap = random.Next(1, 5);
                array[i] = gap + array[i - 1];
            }
            return array;///抄了赵淼同学的一点思路。之前没看到这个作业
        }

        /// <summary>
        /// 查找质数
        /// </summary>
        /// <param name="key"></param>
        private static void findPrimeNumber(int key)
        {
            for (int i = 3; i < key; i++)
            {
                if (isPrime(i))
                {
                    Console.WriteLine(i);
                }
            }

        }
        /// <summary>
        /// i是否是质数
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private static bool isPrime(int number)
        {
            for (int i = 2; i < number / 2; i++)
            {
                if (number % i == 0)
                {
                    return false;///绝对是精华体验，这个套的太强势了。
                }
            }
            return true;
        }



        /// <summary>
        /// 快速排序
        /// </summary>
        /// <param name="left">数组中的第一个下标</param>
        /// <param name="right">数组中的最后一个下标</param>
        /// <param name="array">待排序数组</param>
        /// <returns></returns>
        private static void fastSort(int left, int right, params int[] array)
        {
            if (left == right)//跳出循环条件
            {
                return;
            }
            int center = (left + right) / 2;//获得一个中间的位置
            fastSortBody(center, left, right, array);//找到中间值后进行数组的一侧循环排序

            fastSort(left, center - 1, array);//对数组左侧做整理排序
            fastSort(center + 1, right, array);//对数组右侧做整理排序 
        }


        /// <summary>
        /// 仅供fastSort使用
        /// </summary>
        /// <param name="center"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        private static int fastSortBody(int center, int left, int right, int[] array)
        {
            return -1;//没时间研究他，先放一边
        }

        /// <summary>
        /// 作业输出加减乘除
        /// </summary>
        /// <param name="a">第一个数字</param>
        /// <param name="b">第二个数字</param>
        private static void count(double a, double b)
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
        internal static void LogOn(out bool key)
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

            string verificationcode = "wybz", username = "飞哥最胖", password = "123456";
            Console.WriteLine("请输入验证码（wybz）");
            string getinput = Console.ReadLine();
            if (getinput != verificationcode)
            {
                Console.WriteLine("输入错误");
                key = false;
                return;
            }//else nothing

            Console.WriteLine("请输入用户名（飞哥最胖）");
            string input = Console.ReadLine();
            if (input != username)
            {
                Console.WriteLine("*用户名不存在");
                key = false;
                return;
            }//else nothing

            Console.WriteLine("请在下方输入密码：(123456)");
            string get = Console.ReadLine();
            if (get != password)
            {
                Console.WriteLine("用户名或密码错误");
                key = false;
                return;
            }
            else
            {
                Console.WriteLine("恭喜！登录成功！");
                key = true;
                return;
            }///写在最后，竟然没做出来那个return key. 打脸啊打脸 ---ψ(╰_╯)---
             ///3.15最新消息，隔一天似乎竟然写出来了。
        }



        /// <summary>
        /// 这个只是封装作业，没什么意义
        /// </summary>
        private static void triningForAndWhile()
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
        private static int sum(int number)
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
        private static void nameAndData(string[,] array)
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
        private static int[,] cycleArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = i + j;
                }
                Console.WriteLine();
            }
            //输出数组
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
        public static double[] GetAverage(params double[] array)
        {
            double sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum = sum + array[i];
            }
            double scores = Math.Round((sum / array.Length), 2);
            Console.WriteLine(scores);
            return array;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="result">输入out double result就可以，这里只是多一个返回值</param>
        /// <param name="array">直接输入一个数组就好</param>
        /// <returns></returns>
        public static double GetMaxAndMin(out double result, params double[] array)
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
            return max;
        }



        /// <summary>
        /// 获得一组随机数，可选对其排序，功能采用冒泡排序
        /// </summary>
        /// <param name="Key">输入要获得随机数的个数 例：3，获得3个随机数</param>
        /// <param name="min">输入获得随机数的最小值，默认为0</param>
        /// <param name="max">输入获得随机数的最大值，默认为1000</param>
        /// <param name="sort">如果需要随机数后排序输入“true”</param>
        /// <returns></returns>
        public static int GetRandomNumber(int Key, int min = 0, int max = 1000, bool sort = false)
        {//这个地方想了半天要不要用元组，但是发现3个都是可选参数，就算了吧。元组套上后反而麻烦
            int[] receive = new int[Key];

            for (int i = 0; i < receive.Length; i++)
            {
                receive[i] = new Random().Next(min, max);
            }
            //这是只是为了输出
            for (int i = 0; i < receive.Length; i++)
            {
                Console.Write(receive[i] + ",");
            }
            //Console.WriteLine();

            if (sort == true)
            {//这里跳转到冒泡排序
                Console.WriteLine("下面是排序后的随机数");
                bubbleSort(receive);
            }//else nothing 
            return receive[Key - 1];
        }



        /// <summary>
        /// 猜数字游戏，直接运行，无需参数。
        /// </summary>
        internal static void GuessMe()
        {
            Console.WriteLine("欢迎来到猜数字游戏,这个数字是1000以内的整数");
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
        /// <param name="array">需要传入一个数组</param>
        /// <param name="Key">在传入一个需要查找的值</param>
        /// <returns></returns>
        public static int FindMax(int[] array, int Key)
        {
            bool fond = false;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] == Key)
                {
                    return array[i];
                }
            }
            if (!fond)
            {
                Console.WriteLine("没找到");
            }
            return -1;
        }

        /// <summary>
        /// 交换方法
        /// </summary>
        /// <param name="a">需要ref 引用参数a</param>
        /// <param name="b">需要ref 引用参数b</param>
        public static void Swap(ref int a, ref int b)
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
        private static int binarySeek(int[] array, int Key)
        {
            int left = 0, right = array.Length - 1;
            while (left <= right)
            {
                int middle = (left + right) / 2;
                if (Key == array[middle])
                {
                    Console.WriteLine(middle); //找到查找数字下标
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
        private static int[] bubbleSort(params int[] array)
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
            {//只是为了输出数字
                Console.Write(array[i] + ",");
            }
            return array;
        }

        static void Main(string[] args)
        {



            //findPrimeNumber(230);

            //int a = 18;

            //HomeWork person = new HomeWork();//值的值传递
            //person.ValuePass(a);
            //Console.WriteLine(a);
            //Console.WriteLine("------------------------");

            //HomeWork otherPerson = new HomeWork();//值的引用传递
            //otherPerson.ReferencePass(ref a);
            //Console.WriteLine(a);
            //Console.WriteLine("--------------------------");

            //HomeWork name = new HomeWork { _name = "王月半子" };//引用类型的值传递
            //ChangeName(name);
            //Console.WriteLine(name._name);
            //Console.WriteLine("--------------------------");

            //HomeWork newName = new HomeWork { _name = "王月半子" };//引用类型的引用传递
            //ChangeingName(ref newName);
            //Console.WriteLine(newName._name);

            //new SelfTry();
            //Console.WriteLine();
            //Console.WriteLine(SelfTry.Belong); 

            SelfTry wpz = new SelfTry("wangyuebanzi");
            SelfTry.learn(95);
            SelfTry.enroll(wpz);
        }

    }
    public class SelfTry
    {
        private static string _name;
        public SelfTry(string name)
        {
            _name = name;
        }
        internal static void learn(int scroe)
        {
            Console.WriteLine($"{_name}zai{at}xuexi");
            scroe++;
        }

        static SelfTry[] student = new SelfTry[18];

        internal static void enroll(SelfTry newbie)
        {
            for (int i = 0; i < student.Length - 1; i++)
            {
                if (student[i] == null)
                {
                    student[i] = newbie;
                    return;
                }
            }
        }

        public static string Belong { get; set; }

        static string at = "yuanz";
        static SelfTry()
        {
            Belong = "yuanzhan";
        }

        public SelfTry()
        {

        }
    }
}