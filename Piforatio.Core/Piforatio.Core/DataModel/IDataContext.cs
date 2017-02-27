using System;
using System.Collections.Generic;
using Piforatio.Core.ObjectsAbstract;
using Piforatio.Core.DataModel;

namespace Piforatio.Core.DataModel
{
    public interface IDataContext : IDisposable
    {
        IEnumerable<IProject> GetProjects();
        void UpdateProject(IProject project, ChangedType changeType);
        //IEnumerable<IPTask> GetAllPTasks(bool onlyForActiveProject);
        //IEnumerable<IPTask> GetPTasks(IProject project);
        //void UpdatePTask(IPTask task, IProject baseProject, ChangedType changeType);
    }
}
