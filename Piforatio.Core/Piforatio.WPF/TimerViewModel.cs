using System;
using Piforatio.Core2;

namespace Piforatio.WPF
{
    public class TimerViewModel
    {
        IDateTime _dateTime;
        private Alarmclock _workClock;

        public TimerViewModel(IDateTime dateTime)
        {
            _dateTime = dateTime;
            _workClock = new Alarmclock();
        }

        public TimerViewModel(IDateTime dateTime, int maxWorkTime)
            : this(dateTime)
        {
            //Do nothing
        }

        public object CurrentObjective
        {
            get { return null; }
        }

        public bool IsStarted
        {
            get
            {
                return _workClock.IsRun;
            }
        }

        public object TimePause
        {
            get { return null; }
        }

        public string TimeWork
        {
            get { return _workClock.TotalSeconds.ToTimerFormat(); }
        }

        public void Start()
        {
            _workClock.Start(_dateTime.Now,3600,900);
        }

        public void Execute()
        {
            _workClock.Execute(_dateTime.Now);
        }
    }
}
