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
        public ProjectVMCollection() { }

        public ProjectVMCollection(ProjectModel projectModel)
        {
            _projectModel = projectModel;
            Projects = _projectModel.GetAllData();
        }

        public ObservableCollection<IProject> Projects { get; set; }

        protected ProjectVM _selectedProject;
        public ProjectVM SelectedProject
        {
            get
            {
                return _selectedProject;
            }
            set
            {
                _selectedProject = value;
                NotifyPropertyChanged("SelectedProject");       
            }
        }

        private int _index = -1;
        public int SelectProjectByValue
        {
            get
            {
                return _index;
            }
            set
            {
                _index = value;
                if (_index == -1)
                    SelectedProject = null;
                SelectedProject = new ProjectVM(Projects[_index]); 
            }
        }

        public void UpdateSelectedProject(IProject newProject)
        {
            _projectModel.Update(SelectedProject, ChangedType.Modify);
        }
    }
}
