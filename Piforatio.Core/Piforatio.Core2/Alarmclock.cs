using System;

namespace Piforatio.Core2
{
    public class Alarmclock
    {
        private DateTime _StartTime;
        private bool _isRun = false;
        private bool _isPause = false;
        private bool _isWaitable = false;
        private double _totalTime;
        private double _waitTime;

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

        public void Pause(DateTime now)
        {
            if (_isPause)
                return;
            setTotalSeconds(now);
            _isPause = true;
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

        public void Reset()
        {
            _isRun = false;
            _isPause = false;
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
                Reset();
        }
    }
}