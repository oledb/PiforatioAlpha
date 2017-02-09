using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Specialized;
using Piforatio.Core.ObjectsAbstract;

namespace Piforatio.Core.DataModel
{
    public class ProjectModel : DataModel<IProject>
    {
        public ProjectModel(IDataContextFactory context) : base(context)
        {
            listObject.CollectionChanged += listObject_changed;
        }

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

        protected void listObject_changed(object sender, NotifyCollectionChangedEventArgs args)
        {
            using (var context = dataContext.CreateContext())
            {
                if (args.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (var project in args.NewItems)
                        context.UpdateProjectCollection((IProject)project, ChangedType.Add);
                }
                else if (args.Action == NotifyCollectionChangedAction.Remove)
                {
                    foreach (var project in args.OldItems)
                        context.UpdateProjectCollection((IProject)project, ChangedType.Delete);
                }
                else
                    throw new InvalidOperationException($"Unknown argument type '{args.Action}'");
            }
        }

        public override void UpdateAll()
        {

            using (var context = dataContext.CreateContext())
            {
                var query = (from p in context.GetProjects()
                             select p);
                foreach (var project in query)
                {
                    listObject.Add(project);
                }
            }
        }
    }
}
