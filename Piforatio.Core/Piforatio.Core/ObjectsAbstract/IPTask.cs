using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piforatio.Core.ObjectsAbstract
{
    public interface IPTask : ICoreObject
    {
        int TaskID { get; set; }
        IProject BaseProject { get; set; }
        IAim Aim { get; set; }
        string Desctiption { get; set; }
        IEnumerable<IPTaskPlan> Plans { get; set; }
    }
}
