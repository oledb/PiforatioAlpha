using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Piforatio.Core.ObjectsAbstract;

namespace Piforatio.Core.DataModel
{
    public abstract class PTaskPlanModel : DataModel<IPTaskPlan>
    {
        public abstract IPTask BasePTask { get; }
        
    }
}
