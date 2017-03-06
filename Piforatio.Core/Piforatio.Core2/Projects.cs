using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Piforatio.Core2
{
    public class Projects : BaseArray<Project>
    {
        public List<Project> GetProjects(ProjectType type)
        {
            return Get(p => p.Type == type);
        }

        public List<Project> GetProjects()
        {
            return Get(p => true);
        }
    }
}
