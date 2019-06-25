using System;

namespace Answer
{
    public class Alarm
    {
        public void Check()
        {
            if (Clock.GetClock().GetStatus() == 4) Console.WriteLine("Ring ring ring ring ring !");
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