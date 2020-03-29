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
        public void IsHeadTest()
        {
            DoubleLinkNode node1 = new DoubleLinkNode();
            DoubleLinkNode node2 = new DoubleLinkNode();
            DoubleLinkNode node3 = new DoubleLinkNode();
            DoubleLinkNode node4 = new DoubleLinkNode();
            DoubleLinkNode node5 = new DoubleLinkNode();

            node2.InsertAffter(node1);
            node3.InsertAffter(node2);
            node4.InsertAffter(node3);


            Assert.IsNull(node1.Previous);
            Assert.IsTrue(node1.IsHead);
            Assert.AreEqual(node1.Next, node2);
            Assert.AreEqual(node2.Previous, node1);
            
            Assert.IsFalse(node1.IsTail);

            Assert.IsFalse(node2.IsHead);
            Assert.AreEqual(node2.Next, node3);
            Assert.AreEqual(node3.Previous, node2);
            Assert.IsFalse(node2.IsTail);

            Assert.IsFalse(node3.IsHead);
            Assert.AreEqual(node3.Next, node4);
            Assert.AreEqual(node4.Previous, node3);
            Assert.IsFalse(node3.IsTail);

            ///下面的代码需要使用前解封，都解封会污染其他

            //node5.InsertAffter(node1);
            //Assert.AreEqual(node1.Next, node5);
            //Assert.AreEqual(node5.Previous, node1);
            //Assert.AreEqual(node5.Next, node2);
            //Assert.AreEqual(node2.Previous, node5);

            //node5.InsertAffter(node4);
            //Assert.AreEqual(node4.Next, node5);
            //Assert.AreEqual(node5.Previous, node4);
            //Assert.AreEqual(node5.Next, null);

            //node5.InsertBefore(node3);
            //Assert.AreEqual(node5.Next, node3);
            //Assert.AreEqual(node3.Previous, node5);
            //Assert.AreEqual(node5.Previous, node2);
            //Assert.AreEqual(node2.Next, node5);

            //node5.InsertBefore(node1);
            //Assert.AreEqual(node5.Next, node1);
            //Assert.AreEqual(node1.Previous, node5);
            //Assert.AreEqual(node5.Previous, null);




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

        [Test]
        public void test3()
        {
            HomeWork.DataTimeCount.GetWeek(2000);
            HomeWork.DataTimeCount.GetWeek(1959);
            HomeWork.DataTimeCount.GetWeek(2100);
            HomeWork.DataTimeCount.GetWeek(1);

        }
    }
}