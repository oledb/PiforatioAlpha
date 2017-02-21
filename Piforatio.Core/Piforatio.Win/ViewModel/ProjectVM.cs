using System;
using System.Collections.Generic;
using Piforatio.Core.ObjectsAbstract;
using Piforatio.Core.DataModel;
using Piforatio.Core;

namespace Piforatio.Win.ViewModel
{
    public class ProjectVM : Notifier, IProject
    {
        private int _projectID;
        public int ProjectID
        {
            get { return _projectID; }
            set
            {
                _projectID = value;
                NotifyPropertyChanged("ProjectID");
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyPropertyChanged("Name");
            }
        }

        private DateTime _creationTime;
        public DateTime CreationTime
        {
            get { return _creationTime; }
            set
            {
                _creationTime = value;
                NotifyPropertyChanged("CreationTime");
            }
        }

        protected PTaskModel taskModel;
        public bool IsPTaskLoaded { get; private set; }
        public IEnumerable<IPTask> Tasks
        {
            get; set;
        }

        private ProjectType _type;
        public ProjectType Type
        {
            get { return _type; }

            set
            {
                _type = value;
                NotifyPropertyChanged("Type");
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }

            set
            {
                _description = value;
                NotifyPropertyChanged("Description");
            }
        }

        public void Update<T>(T obj) where T : ICoreObject
        {
            IProject temp = (obj as IProject);
            ProjectID = temp.ProjectID;
            Name = temp.Name;
            Description = temp.Description;
            Type = temp.Type;
            CreationTime = temp.CreationTime;
        }

        public ProjectVM() { }
        
        public ProjectVM(IProject project)
        {
            Update(project);
        }
    }
}
