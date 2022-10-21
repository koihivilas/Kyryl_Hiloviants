using NUnit.Framework;
using System;
using System.Linq;

namespace Basic_knowledge
{
    public class ExtraTask2
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual("128.32.10.1", NumberToIP(2149583361));
        }

        [Test]
        public void Test2()
        {
            Assert.AreEqual("0.0.0.0", NumberToIP(0));
        }

        public string NumberToIP(uint num)
        {
            var bytes = BitConverter.GetBytes(num);
            return string.Join(".", bytes.Reverse());
        }

    }

}
