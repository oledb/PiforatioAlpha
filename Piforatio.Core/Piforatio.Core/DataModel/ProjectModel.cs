using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Piforatio.Core.ObjectsAbstract;
using Piforatio.Core.DataModel;

namespace Piforatio.Core.DataModel
{
    public class ProjectModel : DataModel<IProject>
    {
        public ProjectModel(IDataContextFactory context) : base(context)
        { }

        public override ObservableCollection<IProject> GetAllData()
        {
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

        public override void Update(IProject obj, ChangedType type)
        {
            using (var context = dataContext.CreateContext())
            {
                context.UpdateProjectCollection(obj, type);
            }
        }

        public override void UpdateAll()
        {
            listObject.Clear();
            using (var context = dataContext.CreateContext())
            {
                var query = (from p in context.GetProjects()
                             select p);
                foreach (var p in query)
                {
                    listObject.Add((IProject)p);
                }
            }
        }
    }
}
