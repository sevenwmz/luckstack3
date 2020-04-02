using System;

namespace DontWatch
{
    public class propen
    {

    }
    
    public class student :propen
    {

    }
    public interface ILearn
    {

    }
    public class onetry<T> where T : ILearn ,new()
    {
        //T[] onetry = new T[10];
        T[] value = new T[10];

        public onetry(T[] value)
        {
            this.value = value;
        }

        public T this[int index]
        {
            get => value[index];
        }

        public void Swap<T>(ref T a,ref T b)
        {

        }

    }

    //public interface ILearn
    //{
    //}
}
