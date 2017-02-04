using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piforatio.Core.ObjectsAbstract
{
    public interface IAim : ICoreObject
    {
        int AimID { get; set; }
        bool isCompleted { get; set; }
        int? Value { get; set; }
        string ValueType { get; set; }
        TimeSpan PlanTime { get; set; }
    }

    
}
