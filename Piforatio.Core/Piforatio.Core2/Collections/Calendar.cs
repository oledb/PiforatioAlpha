using System;
using System.Collections.Generic;
using System.Linq;
using LinqKit;

namespace Piforatio.Core2
{
    public class Calendar : EntityCollection<Week>
    {
        private readonly Quants _quants;

        public Calendar(Quants quants, IContextFactory factory) : base(factory)
        {
            _quants = quants;
        }

        protected override void CreateObject(Week obj, PiforatioContext context) { }

        protected override void DeleteObject(Week obj, PiforatioContext context) { }

        protected override IEnumerable<Week> ReadObject(Func<Week, bool> predicate, PiforatioContext context)
        {
            return context.Calendar
                .AsExpandable()
                .Where(predicate); 
        }

        protected override void UpdateObject(Week obj, PiforatioContext context) { }

        public WeekInfo GetWeekInfo(DateTime weekStartDay)
        {
            var dic = new Dictionary<DateTime, int>();
            int total = 0;
            double aver = 0;
            const double daysInWeek = 7.0;
            
            for (int i = 0; i < 7; i++)
            {
                var day = weekStartDay.AddDays(i);
                var allQuants = _quants.Read(day);
                if (allQuants == null)
                {
                    dic[day] = 0;
                    continue;
                }
                int count = 0;
                allQuants.ForEach(q => count += q.Count);
                dic[day] = count;
                total += count;
            }
            aver = Round(total / daysInWeek);

            return new WeekInfo(dic, total, aver);
        }

        private double Round(double d)
        {
            var a = Math.Truncate(d);
            var b = d - a;
            if (b <= 0.125)
                return a;
            if (b > 0.125 && b <= 0.375)
                return a + 0.25;
            if (b > 0.375 && b <= 0.625)
                return a + 0.5;
            if (b > 0.625 && b <= 0.875)
                return a + 0.75;
            return a + 1;
        }
    }
}
