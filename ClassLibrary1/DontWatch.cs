using System;

namespace DontWatch
{
    public class Person
    {
        public virtual void Eat()     //注意关键字 virtual
        {
            Console.WriteLine("人吃饭");
        }
    }

    public class Student : Person
    {
        public override void Eat()   //注意关键字 override
        {
            base.Eat();
            Console.WriteLine("学生吃饭");
        }
    }

    public class Teacher : Student
    {

    }
}
