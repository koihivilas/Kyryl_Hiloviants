using NUnit.Framework;

namespace Basic_knowledge
{
    public class Task3
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual(6, digital_root(132189));
        }

        [Test]
        public void Test2()
        {
            Assert.AreEqual(2, digital_root(493193));
        }

        public int digital_root(int input)
        {
            if (input / 10 == 0) return input;

            var sum = 0;
            while (input != 0)
            {
                sum += input % 10;
                input /= 10;
            }

            return digital_root(sum);
        }
    }

}
