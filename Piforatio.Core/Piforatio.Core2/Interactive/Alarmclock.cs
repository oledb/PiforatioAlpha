using System;

namespace Piforatio.Core2
{
    public class Alarmclock
    {
        private DateTime _startTime;
        private int _intervalCount = 1;
        private double _interval = -1d;
        private double _totalTime;
        private double _waitTime;
        
        public event EventHandler OnClockStop;
        public event EventHandler OnIntervalReach;

        public bool IsStarted { get; private set; }

        public bool IsPaused { get; private set; }

        public double TotalSeconds => IsStarted ? _totalTime : 0;

        public double WaitSecodns => IsStarted ? _waitTime - _totalTime : 0;

        public void Start(DateTime now)
        {
            _waitTime = _waitTime <= 0 ? int.MaxValue : _waitTime;
            _startTime = now;
            IsStarted = true;
            IsPaused = false;
        }

        public void Start(DateTime now, double wait)
        {
            _waitTime = wait;
            Start(now);
        }

        public void Start(DateTime now, double wait, double interval)
        {
            _interval = interval;
            Start(now, wait);
        }

        public void Pause(DateTime now)
        {
            if (IsPaused)
                return;
            SetTotalSeconds(now);
            IsPaused = true;
        }

        public void Stop()
        {
            IsStarted = false;
            IsPaused = false;
            _totalTime = 0;
            _interval = -1d;
            _intervalCount = 1;
        }

        private void SetTotalSeconds(DateTime now)
        {
            _totalTime += (now - _startTime).TotalSeconds;
            _startTime = now;
        }

        public void Execute(DateTime now)
        {
            if (IsStarted && IsPaused) return;
            SetTotalSeconds(now);
            if (WaitSecodns <= 0)
            {
                OnClockStop?.Invoke(this, new EventArgs());
                Stop();
                return;
            }
            if (!(_interval > 0 && _interval * _intervalCount <= _totalTime)) return;
            _intervalCount++;
            OnIntervalReach?.Invoke(this, new EventArgs());
        }
    }
}