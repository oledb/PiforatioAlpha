using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piforatio.Core.ObjectsAbstract
{
    public interface IProject : ICoreObject
    {
        int ProjectID { get; set; }
        string Name { get; set; }
        IEnumerable<IPTask> Tasks { get; set; }
        ProjectType Type { get; set; }
        string Description { get; set; }
        DateTime CreationTime { get; set; }
    }
}
