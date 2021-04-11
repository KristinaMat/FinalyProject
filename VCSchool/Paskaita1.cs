using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VCSchool
{

    public class Paskaita1
    {
        [Test]

        public static void Test4IsEven()
        {
            int leftover = 4 % 2;
            Assert.AreEqual(0, leftover, "4 is not even");
        }
        [Test]
        public static void TestNowis16()
        {
            DateTime CurrentTime = DateTime.Now;//kintamojo apsirasymas
                                                //Assert.AreEqual(16, CurrentTime.Hour, "Now is not 16 hour");//mums reikalinga valanda, tai nurodome .Hour
            Assert.IsTrue(CurrentTime.Hour.Equals(16), "Now is not 16 hour");//keli budai patikrinti
        }

        [Test]

        public static void Test995div3()
        {
            int leftover = 995 % 3;
            Assert.AreEqual(0, leftover, "995 isn't div 3");
        }
        
        [Test]

        public static void TestIfTodayIsThursday()
        {
            DateTime CurrentTime = DateTime.Now;
            Assert.AreEqual(DayOfWeek.Thursday, CurrentTime.DayOfWeek, "Today is not Thursday");
        }
        [Test]
        public static void TestWaitfor5sek()
        {
            Thread.Sleep(5000);
        }
    }
}
