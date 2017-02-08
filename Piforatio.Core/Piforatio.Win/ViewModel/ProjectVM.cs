using System;
using System.Collections.Generic;
using Piforatio.Core.ObjectsAbstract;

namespace Piforatio.Win.ViewModel
{
    public class ProjectVM : Notifier, IProject
    {
        private int _projectID;
        public int ProjectID
        {
            get; set;
        }

        private string _name;
        public string Name
        {
            get; set;
        }

        private DateTime _creationTime;
        public DateTime CreationTime
        {
            get; set;
        }

        public bool IsPTaskLoaded { get; private set; }
        public IEnumerable<IPTask> Tasks
        {
            get; set;
        }

        public void Update<T>(T obj) where T : ICoreObject
        {
            IProject temp = (obj as IProject);
            ProjectID = temp.ProjectID;
            Name = temp.Name; 
            CreationTime = temp.CreationTime;
        }

        public ProjectVM() { }

        public ProjectVM(IProject project)
        {
            
        }
    }
}
