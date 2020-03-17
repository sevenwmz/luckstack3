using System;
using System.Collections.Generic;
using System.Text;

namespace SevenLearnCsharp
{
    class LogIn
    {
        internal static void publish()
        { 
            
        }


    }

    class Student
    {
        static int age;                 //字段：类下面直接声明
        static string name = "阿泰";    //可以在声明时赋值

        public static void greet()
        {
            int age = 18;                    //变量：方法中声明
            age++;                           //使用的是变量
            //如果没有age变量的声明，使用字段age
        }
    }

}
