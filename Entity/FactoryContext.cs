using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class FactoryContext
    {///设计一个类FactoryContext，保证整个程序运行过程中，
     ///无论如何，外部只能获得它的唯一的一个实例化对象。（提示：设计模式之单例）
     ///


        #region 3.设计一个类FactoryContext，保证整个程序运行过程中，无论如何，外部只能获得它的唯一的一个实例化对象。（提示：设计模式之单例）
        //创建 FactoryContext 的一个对象
        private static FactoryContext onlyone; //it's not instance..

        private FactoryContext()
        {
            Console.WriteLine("them are talking if like this type,this class not can be instance,cause private");
        }

        public static FactoryContext GetOnlyOne()//make are instance ?? but here is static..
        {
            return onlyone;
        }

        public void Show()
        {
            Console.WriteLine("I thing here is instance.I'm sure about it.");
        }
        #endregion


    }
}
