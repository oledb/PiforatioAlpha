using System;
using System.Collections.Generic;
using System.Linq;
using LinqKit;
using System.Data.Entity;

namespace Piforatio.Core2
{
    public class Objectives : CrudObject<Objective>
    {
        public Objectives(IContextFactory factory) : base(factory) { }

        public List<Objective> ReadObjectives(string template)
        {
            return Read(o => o.Name.IndexOf(template,
                          StringComparison.OrdinalIgnoreCase) >= 0);
        }

        public List<Objective> ReadObjectives(ObjectiveStatus status)
        {
            return Read(o => o.Status == status);
        }

        protected override void createObject(Objective obj, PiforatioContext context)
        {
            context.Objectives.Add(obj);
        }

        protected override void deleteObject(Objective obj, PiforatioContext context)
        {
            context.Entry(obj).State = EntityState.Deleted;
        }

        protected override IEnumerable<Objective> readObject(Func<Objective, bool> isValid, PiforatioContext context)
        {
            return context.Objectives.AsExpandable().Where(isValid);
        }

        protected override void updateObject(Objective obj, PiforatioContext context)
        {
            context.Entry(obj).State = EntityState.Modified;
        }
    }
}
