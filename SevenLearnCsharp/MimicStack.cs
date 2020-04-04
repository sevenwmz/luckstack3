using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork
{
    public class MimicStack<T>
    {
        ///5.自己实现一个模拟栈（MimicStack）类，入栈出栈数据均为int类型，包含如下功能：
        ///5.1出栈Pop()，弹出栈顶数据
        ///5.2入栈Push()，可以一次性压入多个数据
        ///5.3 出 / 入栈检查，
        ///5.4如果压入的数据已超过栈的深度（最大容量），提示“栈溢出”如果已弹出所有数据，提示“栈已空”
        private T[] stack = new T[10];
        private int top = 0;
        public T pop()
        {
            if (top == 0)
            {
                Console.WriteLine("stack null");
                stack[0] = default(T);
                return stack[0];
            }
            top--;
            return stack[top];
        }

        public void push(T value)
        {
            if (top == stack.Length)
            {
                Console.WriteLine("stack overflow");
                return;
            }
            stack[top] = value;
            top++;
            return;
        }

 

    }
}
