using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using HomeWork;

namespace EntityTest
{
    class MimicStackTest
    {
        [Test]
        public void MimicStaticText()
        {
            ///5.栈的压入弹出
            MimicStack test = new MimicStack();
            Assert.AreEqual(0, test.pop());
            test.push(23);
            Assert.AreEqual(23, test.pop());
            test.push(232);
            Assert.AreEqual(232, test.pop());
            Assert.AreNotEqual(23, test.pop());
            test.push(23);
            test.push(26);
            test.push(213541233);
            test.push(23);
            test.push(24);
            test.push(231);
            test.push(2324);
            test.push(2563);
            test.push(273);
            test.push(233);
            test.push(223);//here already stack overflow.
            test.push(253);//here already stack overflow.
            Assert.AreEqual(233, test.pop());
            Assert.AreNotEqual(253, test.pop());
            Assert.AreEqual(2563, test.pop());
            Assert.AreEqual(2324, test.pop());
            Assert.AreNotEqual(2153, test.pop());
        }
    }
}
