using Entity;
using HomeWork;
using NUnit.Framework;

namespace EntityTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            ///1.为之前作业添加单元测试，包括但不限于：
            ///1.数组中找到最大值
            ///2.找到100以内的所有质数
            ///3.猜数字游戏
            ///4.二分查找
            ///5.栈的压入弹出
            ///

            ///1.数组中找到最大值
            Assert.AreEqual(5331, HistoryHomeWork.FindMax(23, 131, 532, 5331, 123, 521));

            ///2.找到100以内的所有质数
            //Assert.AreEqual(11, HistoryHomeWork.isPrime(100));
            //Assert.AreEqual(100, HistoryHomeWork.isPrime(100));
            //Assert.AreEqual(20, HistoryHomeWork.isPrime(100));
            //Assert.AreEqual(13, HistoryHomeWork.isPrime(100));
            //Assert.AreEqual(53, HistoryHomeWork.isPrime(100));


            ///3.猜数字游戏
            HistoryHomeWork.GuessMe();//这个怎么断言

            ///4.二分查找
            ///  想了半天为啥一直是错的，结果发现原来当时写的是查找下标。。。郁闷
            int[] array = new int[] { 23, 43, 56, 66, 77, 88, 99 };
            Assert.AreEqual(1, HistoryHomeWork.binarySeek(array, 43));

            ///5.栈的压入弹出
            ///
            MimicStack test = new MimicStack();
            test.pop();
            test.push(23);
            test.pop();
            test.push(232);
            test.push(23);
            test.push(23);
            test.push(213541233);
            test.push(23);
            test.push(23);
            test.push(23);
            test.push(23);
            test.push(23);
            test.push(23);
            test.push(23);
            test.push(23);
            test.push(23);
            test.push(23);
            test.pop();

        }


        [Test]
        public void Test2()
        {
            HistoryHomeWork.isPrime(100);
            HistoryHomeWork.isPrime(-100);
            HistoryHomeWork.isPrime(100000);
            HistoryHomeWork.isPrime(23);
        }

    }
}