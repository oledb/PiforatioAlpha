using System;
using Piforatio.Core2;

namespace Piforatio.WPF
{
    public class TimerViewModel : Notifier
    {
        IDateTime _dateTime;
        private Alarmclock _workClock;
        private Alarmclock _pauseClock;
        private int _maxWorkTime = 3600;
        private const int intervalTime = 900;

        public TimerViewModel(IDateTime dateTime)
        {
            _dateTime = dateTime;
            _workClock = new Alarmclock();
        }

        public TimerViewModel(IDateTime dateTime, int maxWorkTime)
            : this(dateTime)
        {
            _maxWorkTime = maxWorkTime;
        }

        public object CurrentObjective
        {
            get { return null; }
        }

        public bool IsStarted
        {
            get
            {
                return _workClock.IsStarted;
            }
        }

        public bool IsPaused
        {
            get
            {
                return _workClock.IsPaused;
            }
        }

        public string PauseTime
        {
            get
            {
                return _pauseClock?.WaitSecodns.ToTimerFormat();
            }
        }

        public string WorkTime
        {
            get
            {
                return _workClock.TotalSeconds.ToTimerFormat();
            }
        }

        public int MaxPauseTime { get; set; } = 900;

        public void Start()
        {
            _workClock.Start(_dateTime.Now, _maxWorkTime, intervalTime);
            NotifyPropertyChanged("IsStarted");
        }

        public void Execute()
        {
            var now = _dateTime.Now;
            if (!IsPaused)
            {
                _workClock.Execute(now);
                NotifyPropertyChanged("TimeWork");
            }
            else
            {
                _pauseClock.Execute(now);
                NotifyPropertyChanged("PauseTime");
            }
        }

        public void Pause()
        {
            var now = _dateTime.Now;
            _workClock.Pause(now);
            _pauseClock = new Alarmclock();
            _pauseClock.Start(now, MaxPauseTime);
            _pauseClock.OnClockStop += (obj, arg) => Stop();
        }

        public void Stop()
        {
            _workClock.Reset();
            NotifyPropertyChanged("TimeWork");
        }
    }
}
