using _17bang.Pages.Repository;
using Entity;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityTest
{
    class BinarySeek
    {
        [Test]
        public void BinarySeekText()
        {






            ///4.二分查找
            int[] array = new int[] { 23, 43, 56, 66, 66, 77, 88, 99, 5331 };
            Assert.AreEqual(1, HistoryHomeWork<int>.binarySeek(array, 43));
            Assert.AreEqual(-1, HistoryHomeWork<int>.binarySeek(array, -1));
            Assert.AreEqual(8, HistoryHomeWork<int>.binarySeek(array, 5331));
            Assert.AreEqual(0, HistoryHomeWork<int>.binarySeek(array, 23));
            Assert.AreEqual(4, HistoryHomeWork<int>.binarySeek(array, 66));
            Assert.AreEqual(5, HistoryHomeWork<int>.binarySeek(array, 77));
            Assert.AreEqual(7, HistoryHomeWork<int>.binarySeek(array, 99));
        }
    }
}
