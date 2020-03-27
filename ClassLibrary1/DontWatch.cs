using System;

namespace DontWatch
{
    public class NowTry
    {
        public static void Praise(object person)
        {
            var attributeOnPerson = WPZAttribute.GetCustomAttribute(person.GetType(), typeof(WPZAttribute));
            if (attributeOnPerson == null)
            {
                Console.WriteLine("no flag");
            }
            else
            {
                WPZAttribute wPZAttribute = attributeOnPerson as WPZAttribute;
                Console.WriteLine($"Female{wPZAttribute.IsFemale},age{wPZAttribute.Age}");
                wPZAttribute.WhoIsMe();
            }
        }
    }
  
    [WPZ("王月半子",Age =23,IsFemale =true)]
    public class Student
    {

    }


    public class Teacher
    {

    }
    public class WPZAttribute : Attribute
    {
        private string _name;

        public WPZAttribute()
        {

        }
        public WPZAttribute(string name)
        {
            _name = name;
        }
        public void WhoIsMe()
        {
            _name = "王月半子";
            Console.WriteLine(_name);
        }
        public int Age { set; get; }
        public bool IsFemale { set; get; }

    }

    public class Self
    {

        private string _try;
        private int _iTry { get; }
        public Self()
        {
            _try = "wpz";
            _iTry = 32;
        }
    }



}
