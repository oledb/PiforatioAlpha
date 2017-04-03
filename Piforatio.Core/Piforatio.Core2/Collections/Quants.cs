using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using LinqKit;

namespace Piforatio.Core2
{
    public class Quants : EntityCollection<Quant>
    {
        public Quants(IContextFactory factory) : base(factory) { }

        public List<Quant> Read(DateTime date)
        {
            return Read(q => DateTime.Compare(q.Time.Date, date.Date) == 0)
                .OrderBy(qs => qs.Time)
                .ToList();
        }

        public List<Quant> Read(int week, int year)
        {
            var start = WeekNumber.FirstDateOfWeek(year, week);
            var end = new DateTime(start.AddDays(7).Ticks);
            var result = Read(q => q.Time >= start.Date && q.Time <= end.Date);
            return result;
        }

        protected override void CreateObject(Quant obj, PiforatioContext context)
        {
            if (obj.Objective != null)
                context.Objectives.Attach(obj.Objective);
        }

        protected override void DeleteObject(Quant obj, PiforatioContext context) { }

        protected override IEnumerable<Quant> ReadObject(Func<Quant, bool> predicate, 
            PiforatioContext context)
        {
            return context.Quants
                .Include(q => q.Objective)
                .AsExpandable()
                .Where(predicate);
        }

        protected override void UpdateObject(Quant obj, PiforatioContext context)
        {
            obj.Objective_ObjectiveID = obj.Objective?.ObjectiveID;
        }
    }
}
