using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Basic_knowledge
{
    public class Task1
    {
        [Test]
        public void Test1()
        {
            var expectedResult = new List<int>() { 1, 2 };
            var actualResult = GetIntegersFromList(new List<object>() { 1, 2, 'a', 'b' });
            CollectionAssert.AreEquivalent(expectedResult, actualResult);
        }

        [Test]
        public void Test2()
        {
            var expectedResult = new List<int>() { 1, 2, 231 };
            var actualResult = GetIntegersFromList(new List<object>() { 1, 2, 'a', 'b', "aasf", '1', "123", 231 });
            CollectionAssert.AreEquivalent(expectedResult, actualResult);
        }

        public List<int> GetIntegersFromList(List<object> input)
        {
            return (from num in input.OfType<int>() select num).ToList();
        }
    }

}