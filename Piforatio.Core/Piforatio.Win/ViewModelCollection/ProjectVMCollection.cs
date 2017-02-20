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
            _projectModel.Load();
            Projects = new ObservableCollection<IProject>(_projectModel.GetAllProjects());
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
                else
                    SelectedProject = new ProjectVM(Projects[_index]); 
            }
        }

        public void AddProject(IProject project)
        {
            _projectModel.Update(project, ChangedType.Add);
            Projects.Add(project);
            SelectProjectByValue = Projects.Count - 1;
        }

        public void RemoveSelectedProject()
        {
            IProject project = (from p in Projects
                                where p.ProjectID == SelectedProject.ProjectID
                                select p).SingleOrDefault();
            if (project == null)
                throw new NullReferenceException($"Internal error. Can not find {SelectedProject.Name} project");
            _projectModel.Update(project, ChangedType.Delete);
            Projects.Remove(project);
            SelectProjectByValue = -1;

        }

        public void SaveSelectedProjectChange()
        {
            _projectModel.Update(SelectedProject, ChangedType.Modify);
            Projects[SelectProjectByValue].Update((IProject)SelectedProject);
        }
    }
}
