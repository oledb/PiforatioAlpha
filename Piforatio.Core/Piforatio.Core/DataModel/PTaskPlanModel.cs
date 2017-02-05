using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Piforatio.Core.ObjectsAbstract;

namespace Piforatio.Core.DataModel
{
    public class PTaskPlanModel : IDataModel<IPTaskPlan>
    {
        public IPTask BasePTask { get; }

        public IEnumerable<IPTaskPlan> GetAllData()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPTaskPlan> GetData(int projectId)
        {
            throw new NotImplementedException();
        }

        public void Update(IPTaskPlan obj)
        {
            throw new NotImplementedException();
        }

        public void UpdateAll()
        {
            throw new NotImplementedException();
        }
    }
}
