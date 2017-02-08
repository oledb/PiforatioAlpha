using System;
using System.Collections.Generic;
using Piforatio.Core.ObjectsAbstract;
using Piforatio.Core.DataModel;

namespace Piforatio.Core.DataModel
{
    public interface IDataContext : IDisposable
    {
        IEnumerable<IProject> GetProjects();
        void UpdateProjectCollection(IProject project, ChangedType changeType);
        IEnumerable<IPTask> GetPTaskAll();
        IEnumerable<IPTask> GetPTask(IProject project);
        void UpdatePTasckCollection(IPTask task, IProject baseProject, ChangedType changeType);
    }
}
