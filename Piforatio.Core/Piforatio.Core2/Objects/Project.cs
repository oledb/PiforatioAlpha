using System.Collections.Generic;

namespace Piforatio.Core2
{
    public class Project
    {
        public int ProjectID { get; set; }
        public string Name { get; set; }
        public ProjectType? Type { get; set; }
        public string Comment { get; set; }
        public ICollection<Objective> Objectives { get; set; }
    }
}
