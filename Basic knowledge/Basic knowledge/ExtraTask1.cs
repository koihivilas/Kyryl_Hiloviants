using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_knowledge
{
    public class ExtraTask1
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual(-1, NextBiggerSameDigits(111));
        }

        [Test]
        public void Test2()
        {
            Assert.AreEqual(153, NextBiggerSameDigits(135));
        }

        public int NextBiggerSameDigits(int num)
        {
            List<int> digits = num.ToString().Select(ch => int.Parse(ch.ToString())).Reverse().ToList();

            int newNum = 0;
            int exp = 1;
            bool found = false;

            for (int i = 0; i < digits.Count - 1; i++)
            {
                if (digits[i] > digits[i + 1] && !found)
                {
                    (digits[i + 1], digits[i]) = (digits[i], digits[i + 1]);
                    found = true;
                }
                newNum += digits[i] * exp;
                exp *= 10;
            }

            newNum += digits[digits.Count - 1] * exp;
            if (!found) return -1;
            return newNum;
        }
        
    }

}
