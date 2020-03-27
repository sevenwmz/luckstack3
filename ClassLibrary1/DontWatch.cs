using System;

namespace DontWatch
{


    public class Person 
    {
        internal string abc;

        public virtual void Eat()     //注意关键字 virtual
        {
            Console.WriteLine("人吃饭");
        }

     
    }



    public class Student :Person
    {
        public int age { set; get; }

        //public override bool Equals(object obj)
        //{
        //    return age == ((Student)obj).age;
        //}
        //public static bool operator ==(Student a, Student b)
        //{
        //    return a.age == b.age;
        //}
        //public static bool operator !=(Student a, Student b)
        //{
        //    return a.age != b.age;
        //}


        //public override void Eat()   //注意关键字 override
        //{
        //    base.Eat();
        //    Console.WriteLine("学生吃饭");
        //}
        //public static implicit operator Person(Student student)
        //{
        //    return new Person
        //    {
        //        abc = student.age.ToString()
        //    };
        //}
    }

    //public class Teacher : Student
    //{
    //    public override void Eat()
    //    {
    //        base.Eat();
    //        Console.WriteLine("super teacher");
    //    }
    //}
}
