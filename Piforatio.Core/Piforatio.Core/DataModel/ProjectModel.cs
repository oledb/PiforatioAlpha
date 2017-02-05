using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;s
using Piforatio.Core.ObjectsAbstract;

namespace Piforatio.Core.DataModel
{
    public class ProjectModel : IDataModel<IProject>
    {
        public IEnumerable<IProject> GetAllData()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IProject> GetData(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(IProject obj)
        {
            throw new NotImplementedException();
        }

        public void UpdateAll()
        {
            throw new NotImplementedException();
        }
    }
}
