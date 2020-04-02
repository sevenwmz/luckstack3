using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using HomeWork;
using SevenLearnCsharp;

namespace EntityTest
{
    class GetCountTest
    {
        [Test]
        public void GetCount()
        {
            //实现GetCount(string container, string target)方法，可以统计出container中有多少个target
            //固化要求，已经查过的字符不能在查。不存在重叠【主要是因为重叠想不出来】
            string text = "天今天，是昨天的明天，是明天的前一天", 
                find = "天",find1 ="是",find2 = "you",find3 ="明天",find4 =",";
            Assert.AreEqual(6, DataTimeCount.GetCount(text,find));
            Assert.AreEqual(2, DataTimeCount.GetCount(text, find1));
            Assert.AreEqual(0, DataTimeCount.GetCount(text, find2));
            Assert.AreEqual(2, DataTimeCount.GetCount(text, find3));
            Assert.AreEqual(0, DataTimeCount.GetCount(text, find4));

        }
    }
}
