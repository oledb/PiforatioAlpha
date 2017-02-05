using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Piforatio.Core.ObjectsAbstract;

namespace Piforatio.Core.DataModel
{
    public abstract class PTaskPlanModel : IDataModel<IPTaskPlan>
    {
        
        public abstract IPTask BasePTask { get; }
        public abstract IEnumerable<IPTaskPlan> GetAllData();
        public abstract IEnumerable<IPTaskPlan> GetData(int projectId);
        public abstract void Update(IPTaskPlan obj);
        public abstract void UpdateAll();
    }
}
