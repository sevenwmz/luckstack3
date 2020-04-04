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
            HistoryHomeWork<int> historyHomeWork = new HistoryHomeWork<int>();
            Assert.AreEqual(5331,historyHomeWork.FindMax(23, 131, 532, 5331, 123, 521));
            Assert.AreEqual(532, historyHomeWork.FindMax(23, 131, 532, 531, 123, 521));
            Assert.AreNotEqual(-1, historyHomeWork.FindMax(23, 131, 532, 5331, 123, 521));
            Assert.AreEqual(5333, historyHomeWork.FindMax(23, 131, 532, 5331, 123, 521, 5333));
            Assert.AreEqual(5444, historyHomeWork.FindMax(5444, 23, 131, 532, 5331, 123, 521));
        }
    }
}
