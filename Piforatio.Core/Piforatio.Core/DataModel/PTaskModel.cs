using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Piforatio.Core.ObjectsAbstract;
using Moq;

namespace Piforatio.Core.DataModel
{
    public class PTaskModel //: DataModel<IPTask>
    {
        public PTaskModel(IDataContextFactory context, IProject project) : base(context)
        {
            BaseProject = project;
        }

        public IProject BaseProject { get; protected set; }

        public ObservableCollection<IPTask> GetAllData()
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

        public void UpdateAll()
        {
            throw new NotImplementedException();
        }
    }
}
