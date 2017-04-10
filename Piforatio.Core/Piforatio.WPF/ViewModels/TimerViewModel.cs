using System;
using Piforatio.Core2;

namespace Piforatio.WPF
{
    public class TimerViewModel : Notifier
    {
        readonly IDateTime _dateTime;
        private readonly Alarmclock _workClock;
        private Alarmclock _pauseClock;
        private readonly int _maxWorkTime = 10801; // 3 hours + 1 sec
        private const int IntervalTime = 900; // 15 minutes

        public virtual event EventHandler OnTimerStop;
        public virtual event EventHandler OnTimerStart;
        public virtual event EventHandler OnIntervalReached;

        public TimerViewModel()
        {
            _workClock = new Alarmclock();
            _workClock.OnIntervalReach += (obj, args) => OnIntervalReached?.Invoke(this, args);
            _workClock.OnClockStop += (obj, args) => OnTimerStop?.Invoke(this, args);
            MaxPauseTime = 900;
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

        public Objective CurrentObjective => null;

        public bool IsStarted => _workClock.IsStarted;

        public bool IsPaused => _workClock.IsPaused;

        public string ClockFace => _pauseClock != null ? _pauseClock.WaitSecodns.ToTimerFormat() : _workClock.TotalSeconds.ToTimerFormat();

        public int MaxPauseTime { get; set; }

        public virtual void Start()
        {
            if (IsPaused)
                _workClock.Start(_dateTime?.Now ?? default(DateTime));
            else
            {
                _workClock.Start(_dateTime?.Now ?? default(DateTime), _maxWorkTime, IntervalTime);
                OnTimerStart?.Invoke(this, new EventArgs());
            }
            _pauseClock = null;
            NotifyPropertyChanged("IsStarted");
            NotifyPropertyChanged("IsPaused");
        }

        public virtual void Execute()
        {
            if (!IsStarted)
                return;
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
            _pauseClock.OnClockStop += (obj, args) => Stop();
            _pauseClock.Start(now, MaxPauseTime);
            NotifyPropertyChanged("ClockFace");
            NotifyPropertyChanged("IsPaused");
        }

        public virtual void Stop()
        {
            _workClock.Stop();
            _pauseClock = null;
            NotifyPropertyChanged("ClockFace");
            NotifyPropertyChanged("IsPaused");
        }
    }
}
