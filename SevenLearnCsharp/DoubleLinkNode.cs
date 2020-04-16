using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HomeWork
{
    public class DoubleLinkNode : IEnumerable
    {
        public int? value;

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

        public static DoubleLinkNode Max(DoubleLinkNode node)
        {
            DoubleLinkNode Max = node;

            foreach (DoubleLinkNode item in node)
            {
                if (item.value > Max.value)
                {
                    Max.value = item.value;
                }
            }
            return Max;
        }


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

        public IEnumerator GetEnumerator()
        {
            return new NodeEnumerator(this);
        }
    }
    public class NodeEnumerator : IEnumerator
    {
        private DoubleLinkNode node;
        private bool end;

        public NodeEnumerator(DoubleLinkNode node)
        {
            this.node = node;
        }
        public object Current => node.Previous;

        int i = 0, j = 0, k = 0;
        public bool MoveNext()
        {///这里是飞哥写的宝码；不要乱动
            if (end)
            {
                return false;
            }

            if (node.IsTail)
            {
                DoubleLinkNode fakeTail = new DoubleLinkNode();
                fakeTail.InsertAfter(node);
                end = true;
            }//else nothing

            node = node.Next;
            return true;

            //if (node.IsHead && i =_ 0)
            //{
            //    i++;
            //    j++;
            //    k++;
            //    node = node.Next.Previous;
            //    return true;
            //}
            //if (node.IsTail && k ==0)
            //{
            //    k++;
            //    j++;
            //    node = node.Previous.Next;
            //    return true;
            //}
            //if (!node.IsHead && j == 0)
            //{
            //    j++;
            //    k++;
            //    node = node.Next.Previous;
            //    return true;
            //}
            //if (!node.IsTail)
            //{
            //    node = node.Next;
            //    return true;
            //}
            //return false;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
