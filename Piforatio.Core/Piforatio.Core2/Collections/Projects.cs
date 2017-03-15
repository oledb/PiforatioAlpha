using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using LinqKit;

namespace Piforatio.Core2
{
    public class Projects : CrudObject<Project>
    {
        public Projects(IContextFactory contextFactory) : base(contextFactory)
        {
        }

        public List<Project> ReadProjectByType(ProjectType type)
        {
            return Read(p => p.Type == type);
        }

        protected override void createObject(Project obj, PiforatioContext context)
        {
            context.Projects.Add(obj);
        }

        protected override void deleteObject(Project obj, PiforatioContext context)
        {
            context.Entry(obj).State = EntityState.Deleted;
        }

        protected override IEnumerable<Project> readObject(Func<Project, bool> isValid, PiforatioContext context)
        {
            return context.Projects.AsExpandable().Where(isValid);
        }

        protected override void updateObject(Project obj, PiforatioContext context)
        {
            context.Entry(obj).State = EntityState.Modified;
        }
    }
}
