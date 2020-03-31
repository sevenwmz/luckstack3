using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork
{
    public class DoubleLinkNode
    {
        public DoubleLinkNode Next { get; private set; }

        public DoubleLinkNode Previous { get; private set; }

        public DoubleLinkNode Id { get; private set; }

        public bool IsHead
        {
            get => Previous == null;
        }

        public bool IsTail
        {
            get => Next == null;
        }

        public void InsertAffter(DoubleLinkNode node)
        {// 1 2 [5] 3 4   :5 = this
            if (node.IsTail)
            {
                node.Next = this;
                this.Previous = node;
            }
            else
            {//2.5 c.3
                DoubleLinkNode nodeNext = node.Next;
                node.Next = this;
                this.Previous = node;

                this.Next = nodeNext;
                this.Next.Previous = this;
            }
        }

        public void InsertBefore(DoubleLinkNode node)
        {
            if (node.IsHead)
            {
                this.Next = node;
                node.Previous = this;
            }
            else
            {
                DoubleLinkNode nodePrevious = node.Previous;
                this.Next = node;
                node.Previous = this;

                this.Previous = nodePrevious;
                this.Previous.Next = this;
            }
        }

        public void Delete()
        {//1 2 3 4      

            if (this.IsHead & this.IsTail)
            {
                Console.WriteLine("寻思啥呢，再删没了");
                return;
            }

            if (this.IsHead)
            {
                this.Next.Previous = null;//1后面的前面等于空
            }
            else if (this.IsTail)
            {
                this.Previous.Next = null;//4前面的后面等于空
            }
            else
            {
                this.Previous.Next = this.Next;//3前面的后面 = 3后面
                this.Next.Previous = this.Previous;//3后面的前面 = 3前面
            }

        }


        //public void Swap(DoubleLinkNode a, DoubleLinkNode b)
        //{                   //1 2 3 4 5
        //    DoubleLinkNode aNext = a.Next;
        //    DoubleLinkNode aPrevies = a.Previous;
        //    DoubleLinkNode nodeBAffter = b.Next.Previous;
        //    DoubleLinkNode nodeBBefore = b.Previous.Next;


        //    DoubleLinkNode nodeAAffter = a.Next.Previous;
        //    DoubleLinkNode nodeABefore = a.Previous.Next;


        //    ///找到原因了，现在是把他们位置和线连好了，但是之前元素的记忆还是之前的位置的成员.
        //    //1 2 3 4 5
        //    //1 4 3 2 5
        //    a.Next = b.Next;
        //    a.Previous = b.Previous;
        //    b.Next = aNext;
        //    b.Previous = aPrevies;
        //    nodeBAffter = a.Next;
        //    nodeBBefore = a.Previous;
        //    nodeAAffter = b.Next;
        //    nodeABefore = b.Previous;


        //    //node2.Swap(node2, node4);
        //    //Assert.AreEqual(node2.Next, node5);
        //    //Assert.AreEqual(node2.Previous, node3);
        //    //Assert.AreEqual(node4.Next, node3);
        //    //Assert.AreEqual(node4.Previous, node1);
        //    //Assert.AreEqual(node3.Next, node2);     ????????????
        //    //Assert.AreEqual(node5.Previous, node2);




        //}


        public void Swap(DoubleLinkNode node)
        {//1 2 3 4 5 : this2 node:4
            // 1 4 3 2 5

            DoubleLinkNode thisPrevies = this.Previous;
            DoubleLinkNode nodeprevies = node.Previous;

            this.Delete();
            node.Delete();
            thisPrevies.InsertBefore(node);
            nodeprevies.InsertBefore(this);


            //DoubleLinkNode Next = this.Next;
            //DoubleLinkNode Previes = this.Previous;
            //DoubleLinkNode nodeNext = node.Previous.Next;//3后面
            //DoubleLinkNode nodePrevious = node.Next.Previous;//5前面
            //this.Next = node.Next;
            //this.Previous = node.Previous;
            //node.Next = Next;
            //node.Previous = Previes;

            //nodeNext = this.Previous.Next;
            //nodePrevious = this.Next.Previous;


        }

        //node2.Swap(node4);
        //    Assert.AreEqual(node2.Next, node5);
        //    Assert.AreEqual(node2.Previous, node3);
        //    Assert.AreEqual(node4.Next, node3);
        //    Assert.AreEqual(node4.Previous, node1);
        //    Assert.AreEqual(node3.Next, node2);
        //    Assert.AreEqual(node5.Previous, node2);
        //    Assert.AreEqual(node3.Previous, node4);
        //    Assert.AreEqual(node1.Next, node4);




    }
}
