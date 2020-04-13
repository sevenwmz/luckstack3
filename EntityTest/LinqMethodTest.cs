using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityTest
{
    class LinqMethodTest
    {
        [Test]
        public void LinqMethod()
        {
            //TestLinq.AssertLinq();
        }




    }
    public static class TestLinq
    {
        //public static void AssertLinq(this Assert assert, object[] expected, object[] actual)
        public static bool AssertLinq<T>(List<object> expected, List<object> actual)
        {
            if (expected != actual)
            {
                return false;
            }
            return true;
        }

    }


}
