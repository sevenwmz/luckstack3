using Entity;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityTest
{
    class FindMax
    {
        [Test]
        public void FindMaxTest()
        {
            Assert.AreEqual(5331, HistoryHomeWork.FindMax(23, 131, 532, 5331, 123, 521));
            Assert.AreEqual(532, HistoryHomeWork.FindMax(23, 131, 532, 531, 123, 521));
            Assert.AreNotEqual(-1, HistoryHomeWork.FindMax(23, 131, 532, 5331, 123, 521));
            Assert.AreEqual(5333, HistoryHomeWork.FindMax(23, 131, 532, 5331, 123, 521, 5333));
            Assert.AreEqual(5444, HistoryHomeWork.FindMax(5444, 23, 131, 532, 5331, 123, 521));
        }
    }
}
