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

        public void Delete(DoubleLinkNode node)
        {//1 2 3 4      
            if (node.IsHead)
            {
                this.Next.Previous = null;//1后面的前面等于空
            }
            else if (node.IsTail)
            {
                this.Previous.Next = null;//4前面的后面等于空
            }
            else
            {
                this.Previous.Next = this.Next;//3前面的后面 = 3后面
                this.Next.Previous = this.Previous;//3后面的前面 = 3前面
            }
            
        }


        public void Swap(DoubleLinkNode a, DoubleLinkNode b)
        {

        }

        







    }
}
