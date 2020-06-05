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
            string Title = "这里是测试新的111生机功能";

            string Keywords = " 关键字1  关键字2  关键字3 关键字1";
            IList<string> keywords = Keywords.Trim().Split(" ");
            for (int i = 0; i < keywords.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(keywords[i]))
                {
                    continue;
                }
                int keywordsId = new ArticleRepository().GetKeywordsId(keywords[i]);
                new ArticleRepository().PlusUsedKeyword(keywordsId);
                int articleId = new ArticleRepository().GetArticleId(Title);
                new ArticleRepository().AttachKeyword(articleId, keywordsId);

                
            }





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
