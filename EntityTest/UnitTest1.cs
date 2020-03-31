using Entity;
using HomeWork;
using NUnit.Framework;

namespace EntityTest
{
    public class Tests
    {
        DoubleLinkNode node1, node2, node3, node4, node5, node6, node7, node8, node9;
        [SetUp]
        public void Setup()
        {
            node1 = new DoubleLinkNode();
            node2 = new DoubleLinkNode();
            node3 = new DoubleLinkNode();
            node4 = new DoubleLinkNode();
            node5 = new DoubleLinkNode();
            node6 = new DoubleLinkNode();
            node7 = new DoubleLinkNode();
            node8 = new DoubleLinkNode();
            node9 = new DoubleLinkNode();

            node2.InsertAffter(node1);
            node3.InsertAffter(node2);
            node4.InsertAffter(node3);
        }

        [Test]
        public void IsHeadAndTailTest()
        {
            Assert.IsNull(node1.Previous);
            Assert.IsTrue(node1.IsHead);
            Assert.IsFalse(node1.IsTail);
            Assert.IsFalse(node2.IsHead);
            Assert.IsFalse(node2.IsTail);
            Assert.IsFalse(node3.IsHead);
            Assert.IsFalse(node3.IsTail);
        }
        [Test]
        public void InsertAffterTest()
        {
            node5.InsertAffter(node1);//1 5 2 3 4
            Assert.AreEqual(node1.Next, node5);
            Assert.AreEqual(node5.Previous, node1);
            Assert.AreEqual(node5.Next, node2);
            Assert.AreEqual(node2.Previous, node5);

            node6.InsertAffter(node3);//1 5 2 3 6 4
            Assert.AreEqual(node3.Next, node6);
            Assert.AreEqual(node4.Previous, node6);
            Assert.AreEqual(node6.Next, node4);
            Assert.AreEqual(node4.Previous, node6);

            node7.InsertAffter(node6);//1 5 2 3 6 7 4
            Assert.AreEqual(node6.Next, node7);
            Assert.AreEqual(node4.Previous, node7);
            Assert.AreEqual(node7.Next, node4);
            Assert.AreEqual(node4.Previous, node7);

            node8.InsertAffter(node1);//1 8 5 2 3 6 7 4
            Assert.AreEqual(node8.Next, node5);
            Assert.IsNull(node1.Previous);
            Assert.AreEqual(node8.Previous, node1);
            Assert.IsNotNull(node8.Next);

            node9.InsertAffter(node4);//8 1 5 2 3 6 7 4 9
            Assert.AreEqual(node4.Next, node9);
            Assert.AreEqual(node9.Previous, node4);
            Assert.IsNotNull(node9.Previous);
            Assert.IsNull(node9.Next);
        }
        [Test]
        public void InsertBeforeTest()
        {
            node5.InsertBefore(node3);//1 2 5 3 4
            Assert.AreEqual(node5.Next, node3);
            Assert.AreEqual(node3.Previous, node5);
            Assert.AreEqual(node5.Previous, node2);
            Assert.AreEqual(node2.Next, node5);

            node6.InsertBefore(node5);//1 2 6 5 3 4
            Assert.AreEqual(node6.Next, node5);
            Assert.AreEqual(node5.Previous, node6);
            Assert.AreEqual(node6.Previous, node2);
            Assert.AreEqual(node2.Next, node6);

            node7.InsertBefore(node1);//7 1 2 6 5 3 4
            Assert.AreEqual(node7.Next, node1);
            Assert.AreEqual(node1.Previous, node7);
            Assert.IsNull(node7.Previous);
            Assert.IsNotNull(node7.Next);

            node8.InsertBefore(node4);//7 1 2 6 5 3 8 4
            Assert.AreEqual(node8.Next, node4);
            Assert.AreEqual(node4.Previous, node8);
            Assert.AreEqual(node8.Previous,node3);
            Assert.IsNotNull(node8.Next);
        }
        [Test]
        public void DeleteHeadTest()
        {
            node1.Delete();// 2 3 4
            Assert.IsNull(node2.Previous);
            Assert.AreEqual(node2.Next, node3);

            node2.Delete();//  3 4
            Assert.IsNull(node3.Previous);
            Assert.AreEqual(node3.Next, node4);

            node3.Delete();//  4
            Assert.IsNull(node4.Previous);
            Assert.IsNull(node4.Next);

            node5.InsertBefore(node4);//5 4
            Assert.IsNotNull(node4.Previous);
            Assert.IsNotNull(node4);
            Assert.AreEqual(node5.Next, node4);

            node5.Delete();// 4
            Assert.IsNull(node4.Previous);
            Assert.IsNull(node4.Next);
        }
        [Test]
        public void DeleteTailTest()
        {
            node4.Delete();//1 2 3 4
            Assert.IsNull(node3.Next);
            Assert.AreEqual(node3.Previous, node2);

            node3.Delete();// 1 2 3 
            Assert.IsNull(node2.Next);
            Assert.AreEqual(node2.Previous, node1);

            node2.Delete();// 1
            Assert.IsNull(node1.Previous);
            Assert.IsNull(node1.Next);

            node5.InsertAffter(node1);//1 5
            Assert.IsNotNull(node5.Previous);
            Assert.IsNotNull(node1);
            Assert.IsNull(node5.Next);
            Assert.AreEqual(node5.Previous, node1);

            node5.Delete();// 1
            Assert.IsNull(node1.Previous);
            Assert.IsNull(node1.Next);
        }
        [Test]
        public void DeleteTest()
        {
            node2.Delete();//1 3 4
            Assert.AreEqual(node1.Next, node3);
            Assert.AreEqual(node3.Previous, node1);

            node3.Delete();//1  4
            Assert.AreEqual(node1.Next, node4);
            Assert.AreEqual(node4.Previous, node1);

            node6.InsertAffter(node1);//1 6 4
            Assert.AreEqual(node1.Next, node6);
            Assert.AreEqual(node6.Previous, node1);
            Assert.AreEqual(node4.Previous, node6);

            node1.Delete();//6 4
            Assert.AreEqual(node6.Next, node4);
            Assert.AreEqual(node4.Previous, node6);

            node7.InsertBefore(node6);//7 6 4
            Assert.AreEqual(node7.Next, node6);
            Assert.AreEqual(node6.Previous, node7);
            Assert.IsNull(node7.Previous);

            node7.Delete();//6 4
            Assert.AreEqual(node6.Next, node4);
            Assert.AreEqual(node4.Previous, node6);

            node6.Delete();// 4
            Assert.IsNull(node4.Next);
            Assert.IsNull(node4.Previous);

            node4.Delete();//只有一个的时候不能被删除
            Assert.AreEqual(node4.Next, null);
            Assert.AreEqual(node4.Previous, null);
        }

        [Test]
        public void SwapTest()
        {
            node2.Swap(node4);
            Assert.AreEqual(node2.Next, node5);
            Assert.AreEqual(node2.Previous, node3);
            Assert.AreEqual(node4.Next, node3);
            Assert.AreEqual(node4.Previous, node1);
            Assert.AreEqual(node3.Next, node2);
            Assert.AreEqual(node5.Previous, node2);
            Assert.AreEqual(node3.Previous, node4);
            Assert.AreEqual(node1.Next, node4);
        }
        [Test]
        public void FindMaxTest()
        {
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





    }
}