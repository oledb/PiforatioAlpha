using System;
using System.Collections.Generic;
using LinqKit;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Piforatio.Core2
{
    public class Quants : CrudObject<Quant>
    {
        public Quants(IContextFactory factory) : base(factory) { }

        public List<Quant> Read(DateTime date)
        {
            return Read(q => DateTime.Compare(q.Time.Date, date.Date) == 0).OrderBy(qs => qs.Time)
                .ToList();
        }

        public List<Quant> Read(int week, int year)
        {
            var start = WeekNumber.FirstDateOfWeek(year, week);
            var end = new DateTime(start.AddDays(7).Ticks);
            var result = Read(q => q.Time >= start.Date && q.Time <= end.Date);
            return result;
        }

        protected override void createObject(Quant obj, PiforatioContext context)
        {
            if (obj.Objective != null)
                context.Objectives.Attach(obj.Objective);
            context.Entry(obj).State = EntityState.Added;
        }

        protected override void deleteObject(Quant obj, PiforatioContext context)
        {
            context.Entry(obj).State = EntityState.Deleted;
        }

        protected override IEnumerable<Quant> readObject(Func<Quant, bool> isValid, PiforatioContext context)
        {
            return context.Quants.Include(q => q.Objective).AsExpandable().Where(isValid);
        }

        protected override void updateObject(Quant obj, PiforatioContext context)
        {
            var old = ReadSingle(o => o.QuantID == obj.QuantID);
            if (obj.Objective != old.Objective)
            {
                context.Objectives.Attach(obj.Objective);
                if (obj.Objective.Quants == null)
                    obj.Objective.Quants = new List<Quant>();
                obj.Objective.Quants.Add(obj);
            }
            if (old.Objective != null)
            {
                //context.Entry(old.Objective).State = EntityState.Modified;
                //context.Entry(obj.Objective).State = EntityState.Modified;
            }
            context.Entry(obj).State = EntityState.Modified;
        }
    }
}
