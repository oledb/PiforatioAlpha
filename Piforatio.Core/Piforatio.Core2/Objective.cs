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
        public string Project { get; set; }
        public ObjectiveStatus? Status { get; set; }

        public void Update(ICoreObject @new)
        {
            var newObj = @new as Objective;
            Name = newObj.Name;
            if (!string.IsNullOrEmpty(newObj.Project))
                Project = newObj.Project;
            if (newObj.Status != null)
                Status = newObj.Status;
        }
    }
}
