using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piforatio.Core.ObjectsAbstract
{
    public interface IPTaskPlan : ICoreObject
    {
        int PTaskID { get; set; }
        IPTask Task { get; set; }
        DateTime Date { get; set; }
        TaskStatus Status { get; set; }
        IEnumerable<IQuant> Quants { get; set; }
    }
}
