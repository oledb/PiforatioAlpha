using System;
using System.Collections.Generic;

namespace Piforatio.Core2
{
    public struct WeekInfo
    {
        internal WeekInfo(Dictionary<DateTime, int> days, int total, double average)
        {
            Days = days;
            TotalCount = total;
            AverageCount = average;
        }

        public Dictionary<DateTime, int> Days { get; private set; }
        public int TotalCount { get; private set; }
        public double AverageCount { get; private set; }
    }
}
