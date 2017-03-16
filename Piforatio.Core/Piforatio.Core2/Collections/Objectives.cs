using LinqKit;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Piforatio.Core2
{
    public class Objectives : CrudObject<Objective>
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

        protected override void createObject(Objective obj, PiforatioContext context)
        {
            if (obj.Project != null)
                context.Projects.Attach(obj.Project);
        }

        protected override void deleteObject(Objective obj, PiforatioContext context)
        {
            // Do nothing.
        }

        protected override IEnumerable<Objective> readObject(Func<Objective, bool> isValid, PiforatioContext context)
        {
            return context.Objectives.AsExpandable().Where(isValid);
        }

        protected override void updateObject(Objective obj, PiforatioContext context)
        {
            obj.Project_ProjectID = obj.Project?.ProjectID;
        }
    }
}
