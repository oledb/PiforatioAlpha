using Piforatio.Core.DataModel;
using Piforatio.Core.ObjectsAbstract;
using Piforatio.Win.Commands;
using Piforatio.Win.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

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
                _selectedProject.PropertyChanged += selectedProject_update;
                NotifyPropertyChanged("SelectedProject");
            }
        }

        protected void selectedProject_update(object sender, PropertyChangedEventArgs args)
        {
            _projectModel.Update((IProject)sender, ChangedType.Modify);
        }
    }
}
