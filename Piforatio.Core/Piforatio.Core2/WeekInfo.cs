using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piforatio.Core2
{
    public class WeekInfo
    {
        internal WeekInfo(Dictionary<DateTime, int> days, int total, double average)
        {
            _days = days;
            _total = total;
            _average = average;
        }
        private Dictionary<DateTime, int> _days;
        public Dictionary<DateTime, int> Days
        {
            get
            {
                return _days;
            }
        }

        private int _total;
        public int TotalCount
        {
            get
            {
                return _total;
            }
        }
        private double _average;
        public double AverageCount
        {
            get { return _average; }
        }
    }
}
