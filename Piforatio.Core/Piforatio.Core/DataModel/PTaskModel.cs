using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Piforatio.Core.ObjectsAbstract;
using Moq;

namespace Piforatio.Core.DataModel
{
    public class PTaskModel //: DataModel<IPTask>
    {
        public PTaskModel(IDataContextFactory context, IProject project) 
        {
            BaseProject = project;
        }

        public IProject BaseProject { get; protected set; }

        public IEnumerable<IPTask> GetTasks()
        {
            throw new NotImplementedException();
        }

        public IPTask GetData(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(IPTask obj, ChangedType type)
        {
            throw new NotImplementedException();
        }

        public void Load()
        {
            throw new NotImplementedException();
        }
    }
}
