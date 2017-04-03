using System;
using System.Collections.Generic;
using System.Linq;
using LinqKit;

namespace Piforatio.Core2
{
    public class Projects : EntityCollection<Project>
    {
        public Projects(IContextFactory contextFactory) : base(contextFactory) { }

        public List<Project> ReadProjectByType(ProjectType type)
        {
            return Read(p => p.Type == type);
        }

        protected override void CreateObject(Project obj, PiforatioContext context) { }

        protected override void DeleteObject(Project obj, PiforatioContext context) { }

        protected override IEnumerable<Project> ReadObject(Func<Project, bool> predicate, PiforatioContext context)
        {
            return context.Projects.AsExpandable().Where(predicate);
        }

        protected override void UpdateObject(Project obj, PiforatioContext context) { }
    }
}
