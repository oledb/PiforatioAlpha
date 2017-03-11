﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }

        protected override void deleteObject(Quant obj, PiforatioContext context)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<Quant> readObject(Func<Quant, bool> isValid, PiforatioContext context)
        {
            throw new NotImplementedException();
        }

        protected override void updateObject(Quant obj, PiforatioContext context)
        {
            throw new NotImplementedException();
        }
    }
}
