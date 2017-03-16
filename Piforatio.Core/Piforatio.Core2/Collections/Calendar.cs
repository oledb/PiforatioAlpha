using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Piforatio.Core2
{
    public class Calendar : CrudObject<Week>
    {
        private Quants _quants;

        public Calendar(Quants quants, IContextFactory factory) : base(factory)
        {
            _quants = quants;
        }

        protected override void createObject(Week obj, PiforatioContext context)
        {
            // Do nothing.
        }

        protected override void deleteObject(Week obj, PiforatioContext context)
        {
            // Do nothing.
        }

        protected override IEnumerable<Week> readObject(Func<Week, bool> isValid, PiforatioContext context)
        {
            return context.Calendar
                .AsExpandable()
                .Where(isValid); 
        }

        protected override void updateObject(Week obj, PiforatioContext context)
        {
            // Do nothing.
        }

        public WeekInfo GetWeekInfo(DateTime weekStartDay)
        {
            var dic = new Dictionary<DateTime, int>();
            int total = 0;
            double aver = 0;
            
            for (int i = 0; i < 7; i++)
            {
                var day = weekStartDay.AddDays(i);
                var list = _quants.Read(day);
                if (list == null)
                {
                    dic[day] = 0;
                    continue;
                }
                int count = 0;
                list.ForEach(q => count += q.Count);
                dic[day] = count;
                total += count;
            }
            aver = Round( total / 7.0 );

            return new WeekInfo(dic, total, aver);
        }

        private double Round(double d)
        {
            var a = Math.Truncate(d);
            var b = d - a;
            if (b <= 0.125)
                return a;
            else if (b > 0.125 && b <= 0.375)
                return a + 0.25;
            else if (b > 0.375 && b <= 0.625)
                return a + 0.5;
            else if (b > 0.625 && b <= 0.875)
                return a + 0.75;
            else
                return a + 1;
        }
    }
}
