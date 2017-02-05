using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Piforatio.Core.ObjectsAbstract;

namespace Piforatio.Core.DataModel
{
    public abstract class ProjectModel : IDataModel<IProject>
    {
        protected List<IProject> listProject;
        public abstract PTaskModel GetPTaskModel(IProject project);

        public abstract IEnumerable<IProject> GetAllData();

        public abstract IProject GetData(int id);

        public abstract void Update(IProject obj);

        public abstract void UpdateAll();
    }
}
