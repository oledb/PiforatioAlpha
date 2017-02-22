using Piforatio.Core.DataModel;
using Piforatio.Core.ObjectsAbstract;
using Piforatio.Win.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Piforatio.Win.ViewModelCollection
{
    public class ProjectVMCollection : Notifier
    {
        protected ProjectModel _projectModel;

        /// <summary>
        /// Initializes a new instance of <see cref="ProjectVMCollection"/> using <see cref="ProjectModel"/>
        /// </summary>
        public ProjectVMCollection(ProjectModel projectModel)
        {
            if (projectModel == null)
                throw new NullReferenceException("Can not initilize an instance of ProjectVMCollection due to null reference");
            _projectModel = projectModel;
            _projectModel.Load();
            Projects = new ObservableCollection<IProject>(_projectModel.GetAllProjects());
        }

        /// <summary>
        /// For data binding only!
        /// </summary>
        public ObservableCollection<IProject> Projects { get; set; }

        protected ProjectVM _selectedProject;

        /// <summary>
        /// For data binding only! To change this property use <see cref="SelectProjectByValue"/>.
        /// </summary>
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

        /// <summary>
        /// Changes <see cref="SelectedProject"/>
        ///<para/>
        /// Can throw default exceptions of <see cref="ObservableCollection{T}"/>
        /// </summary>
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
                NotifyPropertyChanged("SelectProjectByValue");
            }
        }

        /// <summary>
        /// Adds object of <see cref="IProject"/> to the end of <see cref="Projects"/> and sets it in <see cref="SelectedProject"/>
        /// and <see cref="SelectProjectByValue"/>
        /// </summary>
        /// <param name="project"></param>
        public void AddProject(IProject project)
        {
            if (project == null)
                throw new NullReferenceException("Can not add a new project to ProjectVMCollection dut to null reference");
            _projectModel.Update(project, ChangedType.Add);
            Projects.Add(project);
            SelectProjectByValue = Projects.Count - 1;
        }

        /// <summary>
        /// Removes <see cref="SelectedProject"/> and removes it from <see cref="Projects"/>. 
        /// Sets a <see cref="SelectProjectByValue"/> to -1
        /// </summary>
        public void RemoveSelectedProject()
        {
            IProject project = (from p in Projects
                                where p.ProjectID == SelectedProject.ProjectID
                                select p).SingleOrDefault();
            if (project == null)
                throw new NullReferenceException($"Internal error. Can not find {SelectedProject?.Name} project");
            _projectModel.Update(project, ChangedType.Delete);
            Projects.Remove(project);
            SelectProjectByValue = -1;

        }

        /// <summary>
        /// Updates all fields of <see cref="SelectedProject"/>
        /// </summary>
        public void SaveSelectedProjectChange()
        {
            _projectModel.Update(SelectedProject, ChangedType.Modify);
            Projects[SelectProjectByValue].Update((IProject)SelectedProject);
        }
    }
}
