using NUnit.Framework;
using System;

namespace Basic_knowledge
{
    public class Task5
    {
        [Test]
        public void Test1()
        {
            var expectedResult = "(CORWILL, ALFRED)(CORWILL, FRED)(CORWILL, RAPHAEL)(CORWILL, WILFRED)(TORNBULL, BARNEY)(TORNBULL, BETTY)(TORNBULL, BJON)";
            var actualResult = SortInvitationList("Fred:Corwill;Wilfred:Corwill;Barney:TornBull;Betty:Tornbull;Bjon:Tornbull;Raphael:Corwill;Alfred:Corwill");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Test2()
        {
            var expectedResult = "(SMITH, ALAN)(SMITH, ALAN)(TORNBULL, BARNEY)(TORNBULL, BETTY)(TORNBULL, BJON)";
            var actualResult = SortInvitationList("Alan:Smith;Barney:TornBull;Betty:Tornbull;Bjon:Tornbull;Alan:Smith");
            Assert.AreEqual(expectedResult, actualResult);
        }

        public string SortInvitationList(string s)
        {
            s = s.ToUpper();

            string[] names = s.Split(";");
            for (int i = 0; i < names.Length; i++)
            {
                string[] NameSurname = names[i].Split(':');
                names[i] = NameSurname[1] + ", " + NameSurname[0];
            }

            Array.Sort(names);
            string res = "";

            foreach (var name in names)
            {
                res += "(" + name + ")";
            }

            return res;
        }
    }

}
