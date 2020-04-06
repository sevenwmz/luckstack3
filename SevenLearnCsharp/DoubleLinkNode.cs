using System;
using System.Collections;
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

        public bool Max()
        {
            bool result = false;
            ///具体实现以后再想先把方法调用写出来，我太难了
            //if (this > )
            //{
            //    result == true;
            //    return result;
            //}
            return result;
        }

        //DoubleLinkNode nodeNext = node.Next;
        //node.Next = this;//3的后面是6
        //        this.Previous = node;//6前面是3

        //        this.Next = nodeNext;//6的后面是3的后面
        //        this.Next.Previous = this;//6的后面的前面是6
        public void InsertAfter(DoubleLinkNode node)
        {// 1 2 3 [5] 4    :5 = this :3 =node
            DoubleLinkNode nodeNext = node.Next;
            this.Delete();

            node.Next = this;
            this.Previous = node;
            this.Next = nodeNext;
            if (nodeNext != null)
            {
                nodeNext.Previous = this;
                return;
            }
        }

        public void InsertBefore(DoubleLinkNode node)
        {// [5] 1 2 3 4 
            if (node.Previous != null)
            {
                this.InsertAfter(node.Previous);
                return;
            }
            this.Delete();
            this.Next = node;
            node.Previous = this;
        }

        public void Delete()
        {
            DoubleLinkNode oldPrevious = Previous;
            DoubleLinkNode oldNext = Next;

            if (oldPrevious != null)
            {
                oldPrevious.Next = oldNext;
            }//else nothing
            if (oldNext != null)
            {
                oldNext.Previous = oldPrevious;
            }//else nothing

            Previous = Next = null;
        }

        public void Swap(DoubleLinkNode node)
        {//1 2 3 4  : this2 node:3
            DoubleLinkNode thisNext = this.Next;
            DoubleLinkNode thisPrevious = this.Previous;
            DoubleLinkNode nodeNext = node.Next;
            DoubleLinkNode nodePrevious = node.Previous;
            if (this.IsHead && node.IsTail)
            {
                this.Delete();
                node.Delete();
                node.InsertBefore(thisNext);
                this.InsertAfter(nodePrevious);
                return;
            }
            if (this.IsHead)
            {
                this.Delete();
                node.Delete();
                node.InsertBefore(thisNext);
                this.InsertBefore(nodeNext);
                return;
            }
            this.Delete();
            node.Delete();
            this.InsertBefore(nodeNext);
            node.InsertAfter(thisPrevious);
        }


    }
}
