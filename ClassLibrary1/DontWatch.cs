using System;

namespace DontWatch
{


    abstract class selftry
    {
        internal abstract void eat();

        public int some { set; get; }

        internal virtual void greet()
        {

        }

        public selftry()
        {

        }

    }

    internal interface ILearn
    {
        void practies();
    }


    internal interface IPlay
    {
        void practies();
    }



    public class Person : ILearn, IPlay
    {




        public virtual void Eat()     //注意关键字 virtual
        {
            Console.WriteLine("人吃饭");
        }

        void IPlay.practies()
        {
            throw new NotImplementedException();
        }

        void ILearn.practies()
        {
            throw new NotImplementedException();
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
        public override void Eat()
        {
            base.Eat();
            Console.WriteLine("super teacher");
        }
    }
}
