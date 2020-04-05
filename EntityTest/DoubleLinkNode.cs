using Entity;
using HomeWork;
using NUnit.Framework;

namespace EntityTest
{
    public class DoubleLinkNodeText
    {
        DoubleLinkNode node1, node2, node3, node4, node5,node6;
        [SetUp]
        public void Setup()
        {
            node1 = new DoubleLinkNode();
            node2 = new DoubleLinkNode();
            node3 = new DoubleLinkNode();
            node4 = new DoubleLinkNode();
            node5 = new DoubleLinkNode();
            node6 = new DoubleLinkNode();


            node2.InsertAfter(node1);
            node3.InsertAfter(node2);
            node4.InsertAfter(node3);
            node5.InsertAfter(node4);
        }

        /// <summary>
        /// SetUp测试
        /// </summary>
        [Test]
        public void SetUpTest()
        {
            Assert.IsNull(node1.Previous);

            Assert.AreEqual(node1.Next, node2); 
            Assert.AreEqual(node2.Previous, node1);
            Assert.AreEqual(node2.Next, node3); 
            Assert.AreEqual(node3.Previous, node2);
            Assert.AreEqual(node3.Next, node4); 
            Assert.AreEqual(node4.Previous, node3);
            Assert.AreEqual(node4.Next, node5);
            Assert.AreEqual(node5.Previous, node4);

            Assert.IsNull(node5.Next);

        }




        /// <summary>
        /// 没有实现Max的TDD
        /// </summary>
        [Test]
        public void MaxTest()
        {
        //    Assert.IsTrue(node1.Max());
        //    Assert.IsFalse(node2.Max());
        //    Assert.IsFalse(node3.Max());
        //    Assert.IsFalse(node4.Max());
        //    Assert.IsTrue(node5.Max());

        }





        /// <summary>
        /// 头和尾的测试
        /// </summary>
        [Test]
        public void IsHeadAndTailTest()
        {
            Assert.IsNull(node1.Previous);
            Assert.IsTrue(node1.IsHead);

            Assert.IsNull(node5.Next);
            Assert.IsTrue(node5.IsTail);
        }





        /// <summary>
        /// InsertAffter的中间测试
        /// </summary>
        [Test]
        public void InsertAfterTest()
        {
            //插入前 1 2 3 4 5 
            node6.InsertAfter(node1);
            //插入后 1 [6] 5 2 3 4 
            Assert.AreEqual(node1.Next, node6);
            Assert.AreEqual(node6.Previous, node1);

            Assert.AreEqual(node6.Next, node2);
            Assert.AreEqual(node2.Previous, node6);
        }

        /// <summary>
        /// InsertAffter的头和中间插入
        /// </summary>
        [Test]
        public void InsertAfter_HeadAfterMiddle()
        {
            //插入前 1 2 3 4 5 
            node1.InsertAfter(node3);
            //插入后 2 3 [1] 4 5 

            Assert.IsNull(node2.Previous);

            Assert.AreEqual(node3.Next, node1);
            Assert.AreEqual(node1.Previous, node3);

            Assert.AreEqual(node1.Next, node4);
            Assert.AreEqual(node4.Previous, node1);
        }

        /// <summary>
        /// InsertAffter的头插入尾
        /// </summary>
        [Test]
        public void InsertAfter_HeadAfterTail()
        {
            //插入前 1 2 3 4 5 
            node1.InsertAfter(node5);
            //插入后 2 3 4 5 [1] 

            Assert.IsNull(node2.Previous);

            Assert.AreEqual(node5.Next, node1);
            Assert.AreEqual(node1.Previous, node5);

            Assert.IsNull(node1.Next);
        }

        /// <summary>
        /// InsertAffter的尾部插入中间测试
        /// </summary>
        [Test]
        public void InsertAfter_TailAfterMiddle()
        {
            //插入前 1 2 3 4 5
            node5.InsertAfter(node1);
            //插入后 1 [5] 2 3 4 

            Assert.AreEqual(node5.Previous, node1);
            Assert.AreEqual(node1.Next, node5);

            Assert.AreEqual(node5.Next, node2);
            Assert.AreEqual(node2.Previous, node5);

            Assert.IsNull(node4.Next);
        }

        /// <summary>
        /// InsertAffter的中间插入测试
        /// </summary>
        [Test]
        public void InsertAfter_MiddleAfterMiddle()
        {
            //插入前 1 2 3 4 5
            node2.InsertAfter(node4);
            //插入后 1 3 4 [2] 5

            Assert.AreEqual(node2.Previous, node4);
            Assert.AreEqual(node2.Next, node5);

            Assert.AreEqual(node4.Next, node2);
            Assert.AreEqual(node5.Previous, node2);
        }

        /// <summary>
        /// InsertAffter的相邻插入
        /// </summary>
        [Test]
        public void InsertAfter_Neighbor()
        {
            //插入前 1 2 3 4 5
            node2.InsertAfter(node3);
            //插入后 1 [3] [2] 4 5 

            Assert.AreEqual(node1.Next, node3);
            Assert.AreEqual(node3.Previous, node1);

            Assert.AreEqual(node3.Next, node2);
            Assert.AreEqual(node2.Previous, node3);

            Assert.AreEqual(node2.Next, node4);
        }




        /// <summary>
        /// InsertBefore尾部中间插入
        /// </summary>
        [Test]
        public void InsertBeforeTest()
        {
            //InsertBefore依托于InsertAfter，所以只测试一次
            //插入前1 2 3 4 5
            node5.InsertBefore(node3);
            //插入后1 2 [5] 3 4

            Assert.AreEqual(node5.Next, node3);
            Assert.AreEqual(node3.Previous, node5);
            Assert.AreEqual(node5.Previous, node2);
            Assert.AreEqual(node2.Next, node5);
        }




        /// <summary>
        /// 删除头结点
        /// </summary>
        [Test]
        public void Delete_HeadTest()
        {
            //删除前1 2 3 4 5 
            node1.Delete();
            //删除后 2 3 4 5

            Assert.IsNull(node1.Next);
            Assert.IsNull(node2.Previous);

            //删除前 2 3 4 5
            node2.Delete();
            //删除后 3 4 5

            Assert.IsNull(node2.Next);
            Assert.IsNull(node3.Previous);

            //删除前 3 4 5
            node3.Delete();
            //删除后 4 5
            Assert.IsNull(node3.Next);
            Assert.IsNull(node4.Previous);

            //删除前 4 5
            node4.Delete();
            //删除后 5

            Assert.IsNull(node4.Next);
            Assert.IsNull(node5.Previous);


            //最后一个无法被删除
            node5.Delete();

            Assert.IsNull(node5.Previous);
            Assert.IsNull(node5.Next);

        }

        /// <summary>
        /// 删除尾结点
        /// </summary>
        [Test]
        public void Delete_TailTest()
        {
            //删除前 1 2 3 4 5 
            node5.Delete();
            //删除后 1 2 3 4 

            Assert.IsNull(node5.Previous);
            Assert.IsNull(node4.Next);

            //删除前1 2 3 4 
            node4.Delete();
            //删除后1 2 3 

            Assert.IsNull(node4.Previous);
            Assert.IsNull(node3.Next);

            //删除前1 2 3
            node3.Delete();
            //删除后1 2
            Assert.IsNull(node3.Previous);
            Assert.IsNull(node2.Next);

            //删除前 1 2
            node2.Delete();
            //删除后 1

            Assert.IsNull(node2.Previous);
            Assert.IsNull(node1.Next);

            //最后一个不能被删除 1
            node1.Delete();

            Assert.IsNull(node1.Previous);
            Assert.IsNull(node1.Next);
        }

        /// <summary>
        /// 删除头中间结点
        /// </summary>
        [Test]
        public void DeleteTest()
        {
            //删除前1 2 3 4 5
            node2.Delete();
            //删除后1 3 4 5

            Assert.AreEqual(node1.Next, node3);
            Assert.AreEqual(node3.Previous, node1);

            Assert.IsNull(node2.Previous);
            Assert.IsNull(node2.Next);

        }






        /// <summary>
        /// SwapTest中间交换
        /// </summary>
        [Test]
        public void SwapTest()
        {
            //交换前的数字 1 2 3 4 5 
            node2.Swap(node4);
            //交换后的数字 1 [4] 3 [2] 5 

            Assert.AreEqual(node1.Next, node4);
            Assert.AreEqual(node4.Previous, node1);

            Assert.AreEqual(node4.Next, node3);
            Assert.AreEqual(node3.Previous, node4);

            Assert.AreEqual(node3.Next, node2);
            Assert.AreEqual(node2.Previous, node3);

            Assert.AreEqual(node2.Next, node5);
            Assert.AreEqual(node5.Previous, node2);
        }

        /// <summary>
        /// SwapTest相邻交换
        /// </summary>
        [Test]
        public void SwapNeighborTest()
        {
            //交换前的数字 1 2 3 4 5 
            node2.Swap(node3);
            //交换后的数字 1 [3] [2] 4 5 

            Assert.AreEqual(node1.Next, node3);
            Assert.AreEqual(node3.Previous, node1);

            Assert.AreEqual(node3.Next, node2);
            Assert.AreEqual(node3.Previous, node1);

            Assert.AreEqual(node2.Next, node4);
            Assert.AreEqual(node2.Previous, node3);
            
            Assert.AreEqual(node4.Previous, node2);
        }

        /// <summary>
        /// SwapTest头尾交换
        /// </summary>
        [Test]
        public void Swap_HeadAndTail_Test()
        {
            //当前数字 1 2 3 4 5 
            node1.Swap(node5);
            //当前交换后的数字 [5] 2 3 4 [1] 

            Assert.IsNull(node1.Next);
            Assert.IsNull(node5.Previous);

            Assert.AreEqual(node2.Previous, node5);
            Assert.AreEqual(node5.Next, node2);

            Assert.AreEqual(node1.Previous, node4);
            Assert.AreEqual(node4.Next, node1);
        }

        /// <summary>
        /// SwapTest头中交换
        /// </summary>
        [Test]
        public void Swap_HeadAndMiddle_Test()
        {
            //当前数字 1 2 3 4 5 
            node1.Swap(node3);
            //交换后数字 [3] 2 [1] 4 5

            Assert.IsNull(node3.Previous);
            Assert.IsNotNull(node5.Previous);

            Assert.AreEqual(node3.Next, node2);
            Assert.AreEqual(node2.Previous, node3);

            Assert.AreEqual(node2.Next, node1);
            Assert.AreEqual(node1.Previous, node2);

            Assert.AreEqual(node1.Next, node4);
            Assert.AreEqual(node4.Previous, node1);
        }

        /// <summary>
        /// SwapTest相邻交换
        /// </summary>
        [Test]
        public void Swap_Neighbor_Test()
        {
            //当前数字 1 2 3 4 5 
            node2.Swap(node3);
            //交换后数字 1 [3] [2] 4 5

            Assert.AreEqual(node1.Next, node3);
            Assert.AreEqual(node3.Previous, node1);

            Assert.AreEqual(node3.Next, node2);
            Assert.AreEqual(node2.Previous, node3);

            Assert.AreEqual(node2.Next, node4);
            Assert.AreEqual(node4.Previous, node2);
        }

    }
}