using System;

namespace SevenLearnCsharp
{
    class HomeWork
    {

        static void Main(string[] args)
        {





            #region 第六题
            //找到100以内的所有质数（只能被1和它自己整除的数）
            ///先把100以内的数字放入一个数组
            ///然后用循环从1开始除，一直循环到他本身，如果余数为1就装入另一个数组里。
            ///


            ///3.13 最新消息，表示依然懵懵懂懂，不会做

            #endregion


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
            int sum =0 ;
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
        /// 输入数组获得最大值和最小值
        /// </summary>
        /// <param name="array">输入数组</param>
        /// <returns></returns>
        static double GetMaxAndMin(params double[] array)
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
            return max;///return只能return一个，min return不了，这个未解之谜等待飞哥。如果无解，我就考虑在写一次求最小了
        }


        /// <summary>
        /// 获得一组随机数
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
            return receive[Key-1];
        }

        /// <summary>
        /// 猜数字游戏，直接运行，无需参数。
        /// </summary>
        static void GuessMe()
        {
            Console.WriteLine("欢迎来到猜数字游戏");
            Console.WriteLine("你有十次机会猜中它，如果猜不中。网线，打，懂？");
            int guess = new Random().Next(0, 999);
            for (int i = 0; i < 11; i++)
            {
                int input = Convert.ToInt32(Console.ReadLine());
                if (guess > input)
                {
                    Console.WriteLine("小了");
                }
                else if (guess < input)
                {
                    Console.WriteLine("大了");
                }
                else 
                {
                    Console.WriteLine("猜中");
                    if (input == guess && i <= 5)
                    {
                        Console.WriteLine("太棒了");
                        break;
                    }
                    else if (input == guess && i <= 8)
                    {
                        Console.WriteLine("不错");
                        break;
                    }
                    else if (input == guess && i <= 10)
                    {
                        Console.WriteLine("过关");
                        break;
                    }

                }
                if (i == 10)
                {
                    Console.WriteLine("游戏结束，未能过关");
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
            for (int i = 0; i < array.Length-1; i++)
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
        /// 二分查找
        /// </summary>
        /// <param name="array">输入一个已经排好了的数组</param>
        /// <param name="Key">输入要查找的数字</param>
        /// <returns></returns>
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
