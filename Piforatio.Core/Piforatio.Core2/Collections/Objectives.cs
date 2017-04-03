using System;
using System.Collections.Generic;
using System.Linq;
using LinqKit;

namespace Piforatio.Core2
{
    public class Objectives : EntityCollection<Objective>
    {
        const int firstChar = 0;
        public Objectives(IContextFactory factory) : base(factory) { }

        public List<Objective> ReadByNameTemplate(string template)
        {
            return Read(o => o.Name.IndexOf(template,
                          StringComparison.OrdinalIgnoreCase) >= firstChar);
        }

        public List<Objective> ReadByStatus(ObjectiveStatus status)
        {
            return Read(o => o.Status == status);
        }

        protected override void CreateObject(Objective obj, PiforatioContext context)
        {
            if (obj.Project != null)
                context.Projects.Attach(obj.Project);
        }

        protected override void DeleteObject(Objective obj, PiforatioContext context) { }

        protected override IEnumerable<Objective> ReadObject(Func<Objective, bool> predicate, 
            PiforatioContext context)
        {
            return context.Objectives.AsExpandable().Where(predicate);
        }

        protected override void UpdateObject(Objective obj, PiforatioContext context)
        {
            obj.Project_ProjectID = obj.Project?.ProjectID;
        }
    }
}
