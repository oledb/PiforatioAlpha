using System;
using Piforatio.Core2;

namespace Piforatio.WPF
{
    public class TimerViewModel : Notifier
    {
        IDateTime _dateTime;
        private Alarmclock _workClock;
        private Alarmclock _pauseClock;
        private int _maxWorkTime = 7201; // 2 hours + 1 sec
        private const int intervalTime = 900; // 15 minutes

        public event Action<TimerViewModel, EventArgs> OnTimerEnd;
        public event Action<TimerViewModel, EventArgs> OnIntervalReached;

        public TimerViewModel(IDateTime dateTime)
        {
            _dateTime = dateTime;
            _workClock = new Alarmclock();
            _workClock.OnIntervalReach += (obj, args) => OnIntervalReached?.Invoke(this, args);
            _workClock.OnClockStop += (obj, args) => OnTimerEnd?.Invoke(this, args);
            MaxPauseTime = 899;
            
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

        public string ClockFace
        {
            get
            {
                if (_pauseClock != null)
                    return _pauseClock.WaitSecodns.ToTimerFormat();
                else
                    return _workClock.TotalSeconds.ToTimerFormat();
            }
        }

        public int MaxPauseTime { get; set; }

        public void Start()
        {
            if (IsPaused)
                _workClock.Start(_dateTime.Now);
            else
                _workClock.Start(_dateTime.Now, _maxWorkTime, intervalTime);
            _pauseClock = null;
            NotifyPropertyChanged("IsStarted");
            NotifyPropertyChanged("IsPaused");
        }

        public void Execute()
        {
            var now = _dateTime.Now;
            _workClock.Execute(now);
            if (IsPaused)
                _pauseClock.Execute(now);
            NotifyPropertyChanged("ClockFace");
        }

        public void Pause()
        {
            var now = _dateTime.Now;
            _workClock.Pause(now);
            _pauseClock = new Alarmclock();
            _pauseClock.Start(now, MaxPauseTime);
            NotifyPropertyChanged("ClockFace");
            NotifyPropertyChanged("IsPaused");
        }

        public void Stop()
        {
            _workClock.Reset();
            _pauseClock = null;
            NotifyPropertyChanged("ClockFace");
        }
    }
}
