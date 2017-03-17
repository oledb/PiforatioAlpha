using System;

namespace Piforatio.Core2
{
    public class Alarmclock
    {
        private DateTime _StartTime;
        private bool _isRun = false;
        private bool _isPause = false;
        private bool _isWaitable = false;
        private int _intervalCount = 1;
        private double _interval = -1d;
        private double _totalTime;
        private double _waitTime;

        public event Action<Alarmclock, EventArgs> OnClockStop;
        public event Action<Alarmclock, EventArgs> OnIntervalReach;

        public bool IsRun
        {
            get { return _isRun; }
        }

        public double TotalSeconds
        {
            get
            {
                if (_isRun)
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
            _isRun = false;
            _isPause = false;
            _interval = -1d;
            _intervalCount = 1;
        }

        public void Start(DateTime now)
        {
            if (!_isPause)
                _StartTime = now;
            _isRun = true;
            _isPause = false;
        }

        public void Start(DateTime today, double wait)
        {
            _waitTime = wait;
            _isWaitable = true;
            Start(today);
        }

        public void Start(DateTime today, double wait, double interval)
        {
            _interval = interval;
            Start(today, wait);
        }

        public void Pause(DateTime now)
        {
            if (_isPause)
                return;
            setTotalSeconds(now);
            _isPause = true;
        }

        public void Reset()
        {
            initialize();
        }

        private void setTotalSeconds(DateTime now)
        {
            _totalTime = (now - _StartTime).TotalSeconds;
        }

        public void Execute(DateTime now)
        {
            if (_isRun && _isPause)
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
                if(_interval * _intervalCount >= _totalTime)
                {
                    _intervalCount++;
                    OnIntervalReach?.Invoke(this, new EventArgs());
                }
            }
        }
    }
}