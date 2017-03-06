using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piforatio.Core2
{
    public class Objective : ICoreObject
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Project Project { get; set; }
        public ObjectiveStatus? Status { get; set; }

        public void Update(ICoreObject @new)
        {
            var newObj = @new as Objective;
            Name = newObj.Name;
            if (newObj.Project != null)
                Project = newObj.Project;
            if (newObj.Status != null)
                Status = newObj.Status;
        }
    }
}
