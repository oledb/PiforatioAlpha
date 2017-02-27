using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Piforatio.Core.DataModel;
using Piforatio.Core.ObjectsAbstract;
using static Piforatio.Test.Core.FakesFabrica;

namespace Piforatio.Test.Core
{
    public class DataContextMock : IDataContext
    {
        public void Dispose() { }

        bool _isDbEmpty;

        public DataContextMock() : this(false)
        { }

        public DataContextMock(bool isDbEmpty)
        {
            _isDbEmpty = isDbEmpty;
        }

        public IEnumerable<IProject> GetProjects()
        {
            if (!_isDbEmpty)
            {
                int index = 0;
                yield return CreateProject("MVC", new DateTime(2017, 1, 20), index++);
                yield return CreateProject("Point Theory", new DateTime(2017, 1, 10), index++);
                yield return CreateProject("Xamarin", new DateTime(2017, 2, 1), index++);
            }
            else
                yield return null;
        }

        public void VerifyProject(string name, ChangedType changeType)
        {
            if (string.IsNullOrEmpty(_name) || _typeProject == null)
                throw new Exception("Project was not be updated! Input data is null");

            Assert.AreEqual(name, _name);
            Assert.AreEqual(changeType, _typeProject);
        }

        string _name;
        ChangedType? _typeProject;
        public void UpdateProject(IProject project, ChangedType changeType)
        {
            _name = project.Name;
            _typeProject = changeType;
        }

        List<IProject> listProject;
        public IEnumerable<IPTask> GetPTasks(IProject project)
        {
            if (listProject == null)
                listProject = GetProjects().ToList();
            if (project.Name == "MVC")
            {
                int index = 0;
                IPTask task = CreatePTask(listProject[0], "Read book about MVC", index++);
                task.Aim = CreateAim(0, "Pages", 300);
                yield return task;
                task = CreatePTask(listProject[0], "Setup Nuget Packeges", index++);
                task.Aim = CreateAim(1, "Boolean", 0);
                yield return task;
                task = CreatePTask(listProject[0], "Read book about MVC", index++);
                yield return task;
            }
            else
                yield return null;
        }

        IPTask _task;
        ChangedType _typePTask;
        IProject _baseProject;
        public void UpdatePTask(IPTask task, IProject baseProject, ChangedType changeType)
        {
            _task = task;
            _typePTask = changeType;
            _baseProject = baseProject;
        }

        public void VerifyPTask(Func<IPTask, IProject, ChangedType, bool> verify)
        {
            if (!verify(_task, _baseProject, _typePTask))
                throw new Exception("PTask was not be updated!");
        }

        public IEnumerable<IPTask> GetAllPTasks(bool onlyForActiveProject)
        {
            const IProject nullProject = null;
            return GetPTasks(nullProject);
        }
    }
}
