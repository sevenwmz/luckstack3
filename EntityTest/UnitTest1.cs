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
            Assert.AreEqual(node8.Previous, node3);
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
            //这里先痛批飞哥，1 2 3 4，把3插入到1后面，这个本质是交换，把3交换到2前面。
            //飞-脚-头-墙！！！

            //这个存在着重大的语病，交换的本质是已经存在的节点交换，如果要完成那个方法
            //我就需要考虑把Swap和insertAfter揉在一起了。
            node5.InsertAffter(node4);

            node2.Swap( node3);// 1 3 2 4 5
            Assert.AreEqual(node2.Next, node4);
            Assert.AreEqual(node4.Previous, node2);
            Assert.AreEqual(node3.Next, node2);
            Assert.AreEqual(node2.Previous, node3);
            Assert.AreEqual(node1.Next, node3);
            Assert.AreEqual(node3.Previous, node1);
            Assert.AreEqual(node1.Previous, null);
            Assert.AreEqual(node1.Next, node3);

            node3.Swap(node4);// 1 4 2 3 5
            Assert.AreEqual(node1.Next, node4);
            Assert.AreEqual(node4.Previous, node1);
            Assert.AreEqual(node3.Next, node5);
            Assert.AreEqual(node5.Previous, node3);
            Assert.AreEqual(node2.Next, node3);
            Assert.AreEqual(node3.Previous, node2);
            Assert.AreEqual(node2.Previous, node4);
            Assert.AreEqual(node2.Next, node3);
        }

        [Test]
        public void SwapHeadAndTailText()
        {
            node1.Swap(node4);// 2 3 4 1
            Assert.IsNull(node5.Previous);
            Assert.IsNull(node1.Next);
            Assert.AreEqual(node5.Next, node3);
            Assert.AreEqual(node3.Previous, node5);
            Assert.AreEqual(node1.Previous, node4);
            Assert.AreEqual(node4.Next, node1);
        }

        [Test]
        public void FindMaxTest()
        {
            Assert.AreEqual(5331, HistoryHomeWork.FindMax(23, 131, 532, 5331, 123, 521));
            Assert.AreEqual(532, HistoryHomeWork.FindMax(23, 131, 532, 531, 123, 521));
            Assert.AreNotEqual(-1, HistoryHomeWork.FindMax(23, 131, 532, 5331, 123, 521));
            Assert.AreEqual(5333, HistoryHomeWork.FindMax(23, 131, 532, 5331, 123, 521,5333));
            Assert.AreEqual(5444, HistoryHomeWork.FindMax(5444,23, 131, 532, 5331, 123, 521));
        }

        [Test]
        public void BinarySeekText()
        {
            ///4.二分查找
            int[] array = new int[] { 23, 43, 56, 66, 66, 77, 88, 99, 5331 };
            Assert.AreEqual(1, HistoryHomeWork.binarySeek(array, 43));
            Assert.AreEqual(-1, HistoryHomeWork.binarySeek(array, -1));
            Assert.AreEqual(8, HistoryHomeWork.binarySeek(array, 5331));
            Assert.AreEqual(0, HistoryHomeWork.binarySeek(array, 23));
            Assert.AreEqual(4, HistoryHomeWork.binarySeek(array, 66));
            Assert.AreEqual(5, HistoryHomeWork.binarySeek(array, 77));
            Assert.AreEqual(7, HistoryHomeWork.binarySeek(array, 99));
        }

        [Test]
        public void MimicStaticText()
        {
            ///5.栈的压入弹出
            MimicStack test = new MimicStack();
            Assert.AreEqual(0, test.pop());
            test.push(23);
            Assert.AreEqual(23, test.pop());
            test.push(232);
            Assert.AreEqual(232, test.pop());
            Assert.AreNotEqual(23, test.pop());
            test.push(23);
            test.push(26);
            test.push(213541233);
            test.push(23);
            test.push(24);
            test.push(231);
            test.push(2324);
            test.push(2563);
            test.push(273);
            test.push(233);
            test.push(223);//here already stack overflow.
            test.push(253);//here already stack overflow.
            Assert.AreEqual(233, test.pop());
            Assert.AreNotEqual(253, test.pop());
            Assert.AreEqual(2563, test.pop());
            Assert.AreEqual(2324, test.pop());
            Assert.AreNotEqual(2153, test.pop());
        }

        [Test]
        public void IsPrimeTest()
        {
            ///2.找到100以内的所有质数
            Assert.IsTrue(HistoryHomeWork.isPrime(53));
            Assert.IsFalse(HistoryHomeWork.isPrime(96));
            Assert.IsTrue(HistoryHomeWork.isPrime(46));
            Assert.IsFalse(HistoryHomeWork.isPrime(-1));
            Assert.IsTrue(HistoryHomeWork.isPrime(1001));

        }
    }
}