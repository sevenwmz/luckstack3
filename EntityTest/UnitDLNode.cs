using Entity;
using HomeWork;
using NUnit.Framework;

namespace EntityTest
{
    public class DoubleLinkNode
    {
        HomeWork.DoubleLinkNode node1, node2, node3, node4, node5;
        [SetUp]
        public void Setup()
        {
            node1 = new HomeWork.DoubleLinkNode();
            node2 = new HomeWork.DoubleLinkNode();
            node3 = new HomeWork.DoubleLinkNode();
            node4 = new HomeWork.DoubleLinkNode();
            node5 = new HomeWork.DoubleLinkNode();


            node2.InsertAffter(node1);
            node3.InsertAffter(node2);
            node4.InsertAffter(node3);
        }


        [Test]
        public void MaxTest()
        {
            Assert.IsTrue(node1.Max());
            Assert.IsFalse(node2.Max());
            Assert.IsFalse(node3.Max());
            Assert.IsFalse(node4.Max());
            Assert.IsTrue(node5.Max());

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
            //这里是一个新节点5
            node5.InsertAffter(node1);//1 5 2 3 4 
            Assert.AreEqual(node1.Next, node5);

            Assert.AreEqual(node2.Previous, node5);

            Assert.AreEqual(node5.Previous, node1);
            Assert.AreEqual(node5.Next, node2);

            //5 1 2 3 4 
            node1.InsertAffter(node5);
            Assert.AreEqual(node1.Next, node2);
            Assert.AreEqual(node1.Previous, node5);

            Assert.AreEqual(node2.Previous, node1);

            Assert.IsNull(node4.Next);

            Assert.AreEqual(node5.Next, node1);
            Assert.IsNull(node5.Previous);


            node2.InsertAffter(node3);//5 1 3 2 4 
            Assert.AreEqual(node1.Next, node3);

            Assert.AreEqual(node2.Next, node4);
            Assert.AreEqual(node2.Previous,node3);

            Assert.AreEqual(node3.Next, node2);
            Assert.AreEqual(node3.Previous, node1);

            Assert.AreEqual(node4.Previous, node2);
            Assert.IsNull(node4.Next);



            node5.InsertAffter(node4);//1 3 2 4 5 
            Assert.IsNull(node1.Previous);

            Assert.AreEqual(node4.Next, node5);

            Assert.AreEqual(node5.Previous, node4);
            Assert.IsNull(node5.Next);


        }

        [Test]
        public void InsertBeforeTest()
        {
            node5.InsertBefore(node3);//1 2 5 3 4
            Assert.AreEqual(node5.Next, node3);
            Assert.AreEqual(node3.Previous, node5);
            Assert.AreEqual(node5.Previous, node2);
            Assert.AreEqual(node2.Next, node5);


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


            node4.Delete();//只有一个的时候不能被删除
            Assert.AreEqual(node4.Next, null);
            Assert.AreEqual(node4.Previous, null);
        }

        [Test]
        public void SwapTest()
        {

            node5.InsertAffter(node4);//增加一个节点可以方便交换

            //1 2 3 4 5 初始数字
            node2.Swap(node3);// 1 3 2 4 5    当前交换后的数字
            Assert.AreEqual(node2.Next, node4);
            Assert.AreEqual(node4.Previous, node2);
            Assert.AreEqual(node3.Next, node2);
            Assert.AreEqual(node2.Previous, node3);
            Assert.AreEqual(node1.Next, node3);
            Assert.AreEqual(node3.Previous, node1);
            Assert.AreEqual(node1.Previous, null);
            Assert.AreEqual(node1.Next, node3);

            node3.Swap(node4);//当前交换后的数字 1 4 2 3 5  再一次测试，这个有点没必要。
            Assert.AreEqual(node1.Next, node4);
            Assert.AreEqual(node4.Previous, node1);
            Assert.AreEqual(node3.Next, node5);
            Assert.AreEqual(node5.Previous, node3);
            Assert.AreEqual(node2.Next, node3);
            Assert.AreEqual(node3.Previous, node2);
            Assert.AreEqual(node2.Previous, node4);
            Assert.AreEqual(node2.Next, node3);

            node1.Swap(node5);//当前交换后的数字 5 4 2 3 1   这里是头尾交换，就不在新开一个测试项目了
            Assert.IsNull(node1.Next);
            Assert.IsNull(node5.Previous);
            Assert.AreEqual(node4.Previous, node5);
            Assert.AreEqual(node5.Next, node4);
            Assert.AreEqual(node1.Previous, node3);
            Assert.AreEqual(node3.Next, node1);

            node1.Swap(node2);//当前交换后的数字 5 4 1 3 2    这里是尾部和中间交换
            Assert.IsNull(node2.Next);
            Assert.IsNotNull(node1.Next);
            Assert.AreEqual(node2.Previous, node3);
            Assert.AreEqual(node3.Next, node2);
            Assert.AreEqual(node3.Previous, node1);
            Assert.AreEqual(node1.Next, node3);
            Assert.AreEqual(node4.Next, node1);
            Assert.AreEqual(node1.Previous, node4);


            node5.Swap(node1);//当前交换后的数字 1 4 5 3 2   这里头部和中间的交换
            Assert.IsNull(node1.Previous);
            Assert.IsNotNull(node5.Previous);
            Assert.AreEqual(node5.Previous, node4);
            Assert.AreEqual(node4.Next, node5);
            Assert.AreEqual(node4.Previous, node1);
            Assert.AreEqual(node1.Next, node4);

            //当前交换后的数字 4 1 5 3 2   这里相邻交换，
            //node1.Swap(node4);
            
            //Assert.IsNotNull(node1.Previous);
            //Assert.IsNull(node4.Previous);
            //Assert.AreEqual(node1.Previous, node4);
            //Assert.AreEqual(node4.Next, node1);
            //Assert.AreEqual(node5.Previous, node1);
            //Assert.AreEqual(node1.Next, node5);

        }

    }
}