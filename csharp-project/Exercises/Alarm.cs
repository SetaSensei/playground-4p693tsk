using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Answer
{
    [TestClass]
    public class AlarmTest
    {
        [TestMethod]
        public void ShouldNeverRing()
        {
            var alarm = new Alarm();
            Assert.AreEqual(string.Empty, alarm.Check());
        }

        [TestMethod]
        public void ShouldAlwaysRing()
        {
            var alarm = new Alarm();
            Assert.AreEqual("Ring ring ring ring ring !", alarm.Check());
        }

    }

    public class Alarm
    {
        public string Check()
        {
            if (Clock.GetClock().GetStatus() == 4) return "Ring ring ring ring ring !";
            return string.Empty;
        }
    }

    public class Clock
    {
        private Clock()
        {
        }

        private static Clock ClockInstance { get; set; }

        public static Clock GetClock()
        {
            return ClockInstance ?? (ClockInstance = new Clock());
        }

        public int GetStatus()
        {
            if (DateTime.Now.Millisecond % 5 == 0)
                return 5;
            if (DateTime.Now.Millisecond % 4 == 0)
                return 4;
            if (DateTime.Now.Millisecond % 3 == 0)
                return 3;

            return 0;
        }
    }
}