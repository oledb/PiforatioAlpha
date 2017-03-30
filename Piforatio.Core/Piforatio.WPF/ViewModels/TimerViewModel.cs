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

        public virtual event Action<TimerViewModel, EventArgs> OnTimerEnd;
        public virtual event Action<TimerViewModel, EventArgs> OnTimerStop;
        public virtual event Action<TimerViewModel, EventArgs> OnTimerStart;
        public virtual event Action<TimerViewModel, EventArgs> OnIntervalReached;

        public TimerViewModel()
        {
            _workClock = new Alarmclock();
            _workClock.OnIntervalReach += (obj, args) => OnIntervalReached?.Invoke(this, args);
            _workClock.OnClockStop += (obj, args) => OnTimerEnd?.Invoke(this, args);
            MaxPauseTime = 899;
        }

        public TimerViewModel(IDateTime dateTime) : this()
        {
            _dateTime = dateTime;
        }

        public TimerViewModel(IDateTime dateTime, int maxWorkTime)
            : this(dateTime)
        {
            _maxWorkTime = maxWorkTime;
        }

        public Objective CurrentObjective
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

        public virtual void Start()
        {
            if (IsPaused)
                _workClock.Start(_dateTime?.Now ?? default(DateTime));
            else
            {
                _workClock.Start(_dateTime?.Now ?? default(DateTime), _maxWorkTime, intervalTime);
                OnTimerStart?.Invoke(this, new EventArgs());
            }
            _pauseClock = null;
            NotifyPropertyChanged("IsStarted");
            NotifyPropertyChanged("IsPaused");
        }

        public virtual void Execute()
        {
            var now = _dateTime.Now;
            _workClock.Execute(now);
            if (IsPaused)
                _pauseClock.Execute(now);
            NotifyPropertyChanged("ClockFace");
        }

        public virtual void Pause()
        {
            var now = _dateTime?.Now ?? default(DateTime);
            _workClock.Pause(now);
            _pauseClock = new Alarmclock();
            _pauseClock.Start(now, MaxPauseTime);
            NotifyPropertyChanged("ClockFace");
            NotifyPropertyChanged("IsPaused");
        }

        public virtual void Stop()
        {
            _workClock.Stop();
            _pauseClock = null;
            OnTimerStop?.Invoke(this, new EventArgs());
            NotifyPropertyChanged("ClockFace");
        }
    }
}
