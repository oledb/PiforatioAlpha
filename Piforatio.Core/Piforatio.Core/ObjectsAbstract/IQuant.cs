using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piforatio.Core.ObjectsAbstract
{
    public interface IQuant : ICoreObject
    {
        int QuantID { get; set; }
        DateTime StartTime { get; set; }
        IPTaskPlan TaskPlan { get; set; }
        int TimeDurataion { get; set; }
        string Comment { get; set; }
    }
}
