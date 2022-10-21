using NUnit.Framework;
using System.Linq;

namespace Basic_knowledge
{
    public class Task2
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual("T", first_non_repeating_letter("sTreSS"));
        }

        [Test]
        public void Test2()
        {
            Assert.AreEqual("", first_non_repeating_letter("ssttrreess"));
        }

        public string first_non_repeating_letter(string input)
        {
            string lowercaseInput = input.ToLower();

            for (int i = 0; i < lowercaseInput.Length; i++)
            {
                if ((from ch in lowercaseInput where ch == lowercaseInput[i] select ch).Count() == 1)
                {
                    return input.IndexOf(lowercaseInput[i]) == -1 ? lowercaseInput[i].ToString().ToUpper() : lowercaseInput[i].ToString();
                }
            }

            return "";
        }
    }

}