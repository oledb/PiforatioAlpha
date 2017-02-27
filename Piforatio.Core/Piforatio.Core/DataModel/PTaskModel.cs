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
        IDataContextFactory dataContextFactory;
        public PTaskModel(IDataContextFactory factory, IProject project) 
        {
            BaseProject = project;
            dataContextFactory = factory;
            ptaskList = new List<IPTask>();
        }

        public IProject BaseProject { get; protected set; }
        private List<IPTask> ptaskList;

        public IEnumerable<IPTask> GetTasks()
        {
            return ptaskList;
        }

        public IPTask GetData(int id)
        {
            return (from t in ptaskList
                    where t.TaskID == id
                    select t).SingleOrDefault();
        }

        public void Update(IPTask obj, ChangedType type)
        {
            using (var context = dataContextFactory.CreateContext())
            {
                throw new NotImplementedException();
            }
        }

        public void Load()
        {
            using (var context = dataContextFactory.CreateContext())
            {
                throw new NotImplementedException();
            }
        }
    }
}
