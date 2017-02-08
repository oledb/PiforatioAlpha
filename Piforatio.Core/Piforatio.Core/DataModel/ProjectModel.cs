using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Piforatio.Core.ObjectsAbstract;

namespace Piforatio.Core.DataModel
{
    public class ProjectModel : DataModel<IProject>
    {
        public ProjectModel(IDataContextFabrica context) : base(context)
        { }

        public override ObservableCollection<IProject> GetAllData()
        {
            using (var context = dataContext.CreateContext())
            {
                var query = (from p in context.GetData()
                              select p);
                listObject.Clear();
                foreach (var p in query)
                {
                    listObject.Add((IProject)p);
                }
            }
            return listObject;
        }

        public override IProject GetData(int id)
        {
            return (from p in listObject
                    where p.ProjectID == id
                    select p).SingleOrDefault();
        }

        public PTaskModel GetPTaskModel(IProject project)
        {
            return new PTaskModel(dataContext, project);
        }

        public override void Update(IProject obj)
        {
            using (var context = dataContext.CreateContext())
            {
                throw new NotImplementedException();
            }
        }

        public override void UpdateAll()
        {
            using (var context = dataContext.CreateContext())
            {
                throw new NotImplementedException();
            }
        }
    }
}
