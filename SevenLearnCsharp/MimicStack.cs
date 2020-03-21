using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork
{
    public class MimicStack
    {
        ///5.自己实现一个模拟栈（MimicStack）类，入栈出栈数据均为int类型，包含如下功能：
        ///5.1出栈Pop()，弹出栈顶数据
        ///5.2入栈Push()，可以一次性压入多个数据
        ///5.3 出 / 入栈检查，
        ///5.4如果压入的数据已超过栈的深度（最大容量），提示“栈溢出”如果已弹出所有数据，提示“栈已空”
        internal int[] stack = new int[10];
        public int pop()
        {
            for (int i = 0; i < stack.Length; i++)
            {//如果遇到了空位子，或者数组最后一位不是0，那就弹出
                if (stack[i] == 0)
                {
                    Console.WriteLine("小伙砸，“栈已空”你还弹个锤子呦！");
                    return 0;
                }
                if (stack[9] != 0)
                {
                    stack[9] = 0;
                    return 0;
                }
                if (stack[i+1] == 0)
                {
                    Console.WriteLine(stack[i]);
                    stack[i] = 0;
                    return stack[i];
                }

            }
            return 0;
        }
        public int push(int value)
        {
            for (int i = 0; i < stack.Length; i++)
            {
                if (stack[i] == 0)
                {
                    stack[i] = value;
                    return stack[i];
                }
            }
            Console.WriteLine("小伙子，你遇到了传说中的“栈溢出”！");
            return -1;
        }
    }
}
