using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HomeWork
{
    public class DoubleLinkNode :IEnumerable
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
        public void InsertAffter(DoubleLinkNode node)
        {// 1 2 3 4 [5]   :5 = this :4 =node
            DoubleLinkNode nodeNext = node.Next;
            if (this.Next == null && this.Previous == null)
            {
                if (node.IsTail)
                {
                    node.Next = this;
                    this.Previous = node;
                }
                else  // 1 2 3 4 5
                {//:5 = this :1 = node
                 //DoubleLinkNode nodeNext = node.Next;
                    node.Next = this;//3的后面是6
                    this.Previous = node;//6前面是3

                    this.Next = nodeNext;//6的后面是3的后面
                    this.Next.Previous = this;//6的后面的前面是6
                }
            }
            else if (this.Next != null || this.Previous != null)
            {

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
                this.Next = null;
            }
            else if (this.IsTail)
            {
                this.Previous.Next = null;//4前面的后面等于空
                this.Previous = null;
            }
            else
            {
                this.Previous.Next = this.Next;//3前面的后面 = 3后面
                this.Next.Previous = this.Previous;//3后面的前面 = 3前面
                this.Next = null;
                this.Previous = null;
            }

        }

        public void Swap(DoubleLinkNode node)
        {//1 2 3 4  : this2 node:3
            // 1 3 2     2 3 4

            if ((!this.IsHead && !this.IsTail) && (!node.IsHead && !node.IsTail))//是中间交换
            {// 1 2 3 4  --- 1 3 2 4 5
                DoubleLinkNode thisPrevious = this.Previous;//记录下他们的旁边位置来
                DoubleLinkNode nodeNext = node.Next;

                this.Delete();
                node.Delete();

                this.InsertBefore(nodeNext);
                node.InsertAffter(thisPrevious);
            }
            else if (this.IsHead && node.IsTail)//如果头尾交换
            {//5 2 3 4 1
                DoubleLinkNode thisNext = this.Next;//记录下他们的旁边位置来
                DoubleLinkNode nodePrevious = node.Previous;

                this.Delete();
                node.Delete();

                this.InsertAffter(nodePrevious);
                node.InsertBefore(thisNext);
            }

        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
