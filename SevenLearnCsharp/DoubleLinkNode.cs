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
        {//1 2 [5] 3 4
            if (node.IsHead)
            {
                this.Next = node;
                node.Previous = this;
            }
            else
            {
                DoubleLinkNode nodePrevious = node.Previous;
                node.Previous = nodePrevious;
                this.Next = node;
                node.Previous = this;

                this.Previous = nodePrevious;
                this.Previous.Next = this;
            }
        }

        public void Swap(DoubleLinkNode a, DoubleLinkNode b)
        {

        }

        public void Delete()
        {

        }







    }
}
