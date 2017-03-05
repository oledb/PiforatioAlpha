using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piforatio.Core2
{
    public class Objective
    {
        public int ObjectiveID { get; set; }
        public string Name { get; set; }
        public string Project { get; set; }
        public ObjectiveStatus Status { get; set; }
    }
}
