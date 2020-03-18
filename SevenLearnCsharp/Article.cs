using System;
using System.Collections.Generic;
using System.Text;

namespace SevenLearnCsharp
{
    class Article
    {

        private string _name;
        private int _age;

        internal int Age
        {
            set
            {
                if (value < 0 || 100 < value)
                {
                    Console.WriteLine("wrong");
                }
                _age = value;
            }
            get { return _age; }
        }


        internal void Show1(int i)
        {
            ++i;   //方法内部i增加，传入进来的i不变
            Console.WriteLine(i);
        }
        internal void Show2(ref int i) 
        {
            ++i;//外部的i也会改变
            Console.WriteLine(i);
        }

        internal int age;
        internal void grow(Article article)
        {
            article.age++;
        }




        internal void GetAge(Article age)
        {
            //age = 30;


            //Article other = new Article();//给other新new一个object

            //other._age = age._age;       ///这种状态下把name的地址赋值给变量other，
            //++other._age;                 ///name的本身地址不会发生任何改变
            //Console.WriteLine(other);
        }
        internal void OtherGetAge(ref Article age)
        {
            Article other = new Article();//给other新new一个object

            other._age = age._age;       ///这种状态下把name的地址赋值给变量other，
            ++other._age;                 ///name也会随之发生改变
            Console.WriteLine(other);
        }



        //public void SetAge(int age)
        //{
        //    if (age < 0 || 100 < age)
        //    {
        //        Console.WriteLine("输入错误");
        //        return;
        //    }
        //    _age = age;
        //}
        //public int GetAge()
        //{
        //    return _age;
        //}

        public Article()
        {

        }

        public Article(string name)
        {
            //this._name = 小黄;
        }
        public Article(string name, int age) : this(name)
        {
            this._age = age;
        }

    }
}
