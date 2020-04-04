using HomeWork;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityTest
{
    class MimicJoinTest
    {
        [Test]
        public void MimicJoin()
        {///本来打算用泛型做这个，但是实在搞不定运算符的问题，这里留个影子，期待飞哥解惑(☆▽☆)
            Assert.AreEqual("w!p!z", DataTimeCount.MimicJoin("!", new string[] { "w", "p", "z" }));
            Assert.AreEqual("a-b-c-d", DataTimeCount.MimicJoin("-", new string[] { "a", "b", "c", "d" }));
            Assert.AreNotEqual(1 - 2 - 3 - 4, DataTimeCount.MimicJoin("-", new string[] { "1", "2", "3", "4" }));
            Assert.AreEqual("a@b@c@d", DataTimeCount.MimicJoin("@", new string[] { "a", "b", "c", "d" }));
            Assert.AreEqual("a$4/b$4/c$4/d", DataTimeCount.MimicJoin("$4/", new string[] { "a", "b", "c", "d" }));
            Assert.AreEqual("aabacad", DataTimeCount.MimicJoin("a", new string[] { "a", "b", "c", "d" }));
        }
    }
}
