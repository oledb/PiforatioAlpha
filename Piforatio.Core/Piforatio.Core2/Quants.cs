using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piforatio.Core2
{
    public class Quants : BaseArray<Quant>
    {
        public Quants() : base() { }

        public List<Quant> GetQuants(DateTime date)
        {
            return Get(q => DateTime.Compare(q.Time.Date, date.Date) == 0).OrderBy(qs => qs.Time)
                .ToList();
        }

        public List<Quant> GetQuants(int week, int year)
        {
            var start = WeekNumber.FirstDateOfWeek(year, week);
            var end = new DateTime(start.AddDays(7).Ticks);
            var result = Get(q => q.Time >= start.Date && q.Time <= end.Date);
            return result;
        }
    }
}
