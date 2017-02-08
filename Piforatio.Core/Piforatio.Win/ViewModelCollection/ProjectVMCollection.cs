﻿using System;
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

        }

        public ObservableCollection<IProject> Projects { get; }

        public ProjectVM SelectedProject { get; }

        
        public int? SelectProjectByID
        {
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
