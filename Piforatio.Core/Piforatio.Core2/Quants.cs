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

        public ReadOnlyCollection<Quant> GetQuants(DateTime date)
        {
            var result = (from q in list
                          where DateTime.Compare(q.Time.Date, date.Date) == 0
                          orderby q.Time
                          select q).ToList();

            return result.AsReadOnly();
        }

        public ReadOnlyCollection<Quant> GetQuants(int week, int year)
        {
            var start = WeekNumber.FirstDateOfWeek(year, week);
            var end = new DateTime(start.AddDays(7).Ticks);
            var result = (from q in list
                          where (q.Time >= start.Date && q.Time <= end.Date)
                          select q).ToList();
            return result.AsReadOnly();
        }

        public void Update(int id, Quant @new)
        {
            var quant = list.Find(q => q.QuantID == id);
            quant.Project = @new.Project;
            quant.Objective = @new.Objective;
            quant.Comment = @new.Comment;
            quant.Time = @new.Time;
        }
    }
}
