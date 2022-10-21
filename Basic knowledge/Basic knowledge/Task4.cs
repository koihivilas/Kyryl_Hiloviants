using NUnit.Framework;

namespace Basic_knowledge
{
    public class Task4
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual(4, NumberOfPairs(new int[] { 1, 3, 6, 2, 2, 0, 4, 5 }, 5));
        }

        [Test]
        public void Test2()
        {
            Assert.AreEqual(0, NumberOfPairs(new int[] { 5, 9, 1, 7, 2 }, 5));
        }

        public int NumberOfPairs(int[] input, int target)
        {
            var count = 0;

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i + 1; j < input.Length; j++)
                {
                    if (input[i] + input[j] == target) count++;
                }
            }

            return count;
        }
    }

}
