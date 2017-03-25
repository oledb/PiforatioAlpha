using System;
using Piforatio.Core2;

namespace Piforatio.WPF
{
    public class TimerViewModel
    {
        IDateTime _dateTime;

        public TimerViewModel(IDateTime dateTime)
        {
            _dateTime = dateTime;
        }

        public object CurrentObjective
        {
            get { return null; }
        }

        public string EndYear
        {
            get { return getEndYear(); }
        }

        public bool IsStarted { get; private set; }

        public object TimePause
        {
            get { return null; }
        }

        public string TimeWork
        {
            get { return "00:00:00"; }
        }

        private string getEndYear()
        {
            var date = _dateTime.Now;
            var nextYear = date.Year + 1;
            var nextDate = new DateTime(nextYear, 1, 1, 0, 0, 0);
            var totalHours = (nextDate - date).TotalHours;
            return Convert.ToInt32(totalHours).ToString() ;
        }
    }
}
