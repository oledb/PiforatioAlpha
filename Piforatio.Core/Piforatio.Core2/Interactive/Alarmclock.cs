using System;

namespace Piforatio.Core2
{
    public class Alarmclock
    {
        private DateTime _StartTime;
        private bool _isStarted = false;
        private bool _isPaused = false;
        private bool _isWaitable = false;
        private int _intervalCount = 1;
        private double _interval = -1d;
        private double _totalTime;
        private double _waitTime;

        public event Action<Alarmclock, EventArgs> OnClockStop;
        public event Action<Alarmclock, EventArgs> OnIntervalReach;

        public bool IsStarted
        {
            get { return _isStarted; }
        }

        public bool IsPaused
        {
            get
            {
                return _isPaused;
            }
        }

        public double TotalSeconds
        {
            get
            {
                if (_isStarted)
                    return _totalTime;
                else
                    return 0;
            }
        }
        
        public double WaitSecodns
        {
            get
            {
                if (_isWaitable)
                    return _waitTime - _totalTime;
                else
                    return 0;
            }
        }

        private void initialize()
        {
            _isStarted = false;
            _isPaused = false;
            _totalTime = 0;
            _interval = -1d;
            _intervalCount = 1;
        }

        public void Start(DateTime now)
        {
            _StartTime = now;
            _isStarted = true;
            _isPaused = false;
        }

        public void Start(DateTime now, double wait)
        {
            _waitTime = wait;
            _isWaitable = true;
            Start(now);
        }

        public void Start(DateTime now, double wait, double interval)
        {
            _interval = interval;
            Start(now, wait);
        }

        public void Pause(DateTime now)
        {
            if (_isPaused)
                return;
            setTotalSeconds(now);
            _isPaused = true;
        }

        public void Reset()
        {
            initialize();
        }

        private void setTotalSeconds(DateTime now)
        {
            _totalTime += (now - _StartTime).TotalSeconds;
            _StartTime = now;
        }

        public void Execute(DateTime now)
        {
            if (_isStarted && _isPaused)
                return;
            setTotalSeconds(now);
            if (_isWaitable && WaitSecodns <= 0)
            {
                OnClockStop?.Invoke(this, new EventArgs());
                initialize();
                return;
            }
            if (_isWaitable && _interval > 0)
            {
                if(_interval * _intervalCount <= _totalTime)
                {
                    _intervalCount++;
                    OnIntervalReach?.Invoke(this, new EventArgs());
                }
            }
        }
    }
}