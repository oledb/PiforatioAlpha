using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Piforatio.Core.ObjectsAbstract;

namespace Piforatio.Core.DataModel
{
    public class PTaskModel : IDataModel<IPTask>
    {
        public IProject BaseProject { get; }
        public IEnumerable<IPTask> GetAllData()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPTask> GetData(int projectId)
        {
            throw new NotImplementedException();
        }

        public void Update(IPTask obj)
        {
            throw new NotImplementedException();
        }

        public void UpdateAll()
        {
            throw new NotImplementedException();
        }
    }
}
