using System;
using System.Linq;
using System.Collections.ObjectModel;
using Piforatio.Core.ObjectsAbstract;
using Piforatio.Win.ViewModel;
using Piforatio.Core.DataModel;

namespace Piforatio.Win.ViewModelCollection
{
    public class ProjectVMCollection : Notifier
    {
        protected ProjectModel _projectModel;
        public ProjectVMCollection(ProjectModel projectModel)
        {
            _projectModel = projectModel;
        }

        public ObservableCollection<IProject> Projects
        {
            get
            {
                return _projectModel.GetAllData();
            }
        }

        protected ProjectVM _selectedProject;
        public ProjectVM SelectedProject
        {
            get
            {
                return _selectedProject;
            }
        }

        
        public int? SelectProjectByID
        {
            set
            {
                if (value == null) return;

                var temp = (from p in Projects
                            where p.ProjectID == value
                            select p).SingleOrDefault();

                if (temp == null) return;

                _selectedProject = new ProjectVM(temp);
                NotifyPropertyChanged("SelectedProject");
            }
        }

        
    }
}
