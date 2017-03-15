using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
