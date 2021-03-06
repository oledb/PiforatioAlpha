﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Specialized;
using System.Collections.Generic;
using Piforatio.Core.ObjectsAbstract;

namespace Piforatio.Core.DataModel
{
    public class ProjectModel //: DataModel<IProject>
    {
        private IDataContextFactory _dataContextFactory;
        private List<IProject> _listProject;

        public ProjectModel(IDataContextFactory contextFactory) {
            _dataContextFactory = contextFactory;
            _listProject = new List<IProject>();
        }

        public List<IProject> GetAllProjects()
        {
            return _listProject;
        }

        public IProject GetProject(int id)
        {
            return (from p in _listProject
                    where p.ProjectID == id
                    select p).SingleOrDefault();
        }

        public PTaskModel GetPTaskModel(IProject project)
        {
            return new PTaskModel(_dataContextFactory, project);
        }

        public void Update(IProject obj, ChangedType type)
        {
            using (var context = _dataContextFactory.CreateContext())
            {
                context.UpdateProject(obj, type);
            }
        }

        public void Load()
        {

            using (var context = _dataContextFactory.CreateContext())
            {
                var query = context.GetProjects();
                if (query == null) return;
                foreach (var project in query)
                {
                    _listProject.Add(project);
                }
            }
        }
    }
}
