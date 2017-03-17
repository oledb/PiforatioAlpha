using System;

namespace Piforatio.Core2
{
    public class Alarmclock
    {
        public Alarmclock()
        {
        }

        private DateTime _now;
        public double TotalSeconds { get; private set; }
        
        public void Start(DateTime now)
        {
            _now = now;
        }

        public void Stop(DateTime now)
        {
            TotalSeconds = (now - _now).TotalSeconds; ;
        }
    }
}