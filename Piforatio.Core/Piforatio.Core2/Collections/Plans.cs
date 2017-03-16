using LinqKit;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Piforatio.Core2
{
    public class Plans : EntityCollection<Plan>
    {
        public Plans(IContextFactory contextFactory) : base(contextFactory) { }

        public List<Plan> ReadByDate(DateTime date)
        {
            return Read(p => p.Date.Date == date.Date);
        }

        protected override void createObject(Plan obj, PiforatioContext context)
        {
            if (obj.Objective != null)
                context.Objectives.Attach(obj.Objective);
        }

        protected override void deleteObject(Plan obj, PiforatioContext context) { }

        protected override IEnumerable<Plan> readObject(Func<Plan, bool> isValid, 
            PiforatioContext context)
        {
            return context.Plans
                .Include(p => p.Objective)
                .Include(p => p.Objective.Project)
                .AsExpandable()
                .Where(isValid);
        }

        protected override void updateObject(Plan obj, PiforatioContext context)
        {
            obj.Objective_ObjectiveID = obj.Objective?.ObjectiveID;
        }
    }
}
