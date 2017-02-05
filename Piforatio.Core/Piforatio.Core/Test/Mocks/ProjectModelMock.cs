using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Piforatio.Core.DataModel;
using Piforatio.Core.ObjectsAbstract;

namespace Piforatio.Core.Test.Mocks
{
    public class ProjectModelMock : ProjectModel
    {
        public ProjectModelMock()
        {
            
        }

        public override IEnumerable<IProject> GetAllData()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<IProject> GetData(int id)
        {
            throw new NotImplementedException();
        }

        public override PTaskModel GetPTaskModel(IProject project)
        {
            throw new NotImplementedException();
        }

        public override void Update(IProject obj)
        {
            throw new NotImplementedException();
        }

        public override void UpdateAll()
        {
            throw new NotImplementedException();
        }
    }
}
