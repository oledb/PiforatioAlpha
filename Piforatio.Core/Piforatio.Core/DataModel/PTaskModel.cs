using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Piforatio.Core.ObjectsAbstract;

namespace Piforatio.Core.DataModel
{
    public abstract class PTaskModel : DataModel<IPTask>
    {
        public IProject BaseProject { get; }

        public PTaskPlanModel GetPlanModel (IPTask task)
        {
            throw new NotImplementedException();
        }

    }
}
