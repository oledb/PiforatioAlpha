using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Piforatio.Core.DataModel;
using Piforatio.Core.ObjectsAbstract;
using static Piforatio.Test.Core.FakesFabrica;

namespace Piforatio.Test.Core
{
    public class DataContextMock : IDataContext
    {
        public void Dispose() { }

        bool _isFull;

        public DataContextMock() : this(true)
        { }

        public DataContextMock(bool isFull)
        {
            _isFull = isFull;
        }

        public IEnumerable<IProject> GetProjects()
        {
            if (_isFull)
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
            if (string.IsNullOrEmpty(_name) || _type == null)
                throw new Exception("Data was not be updated! Input data is null");

            Assert.AreEqual(name, _name);
            Assert.AreEqual(changeType, _type);
        }

        string _name;
        ChangedType? _type;
        public void UpdateProjectCollection(IProject project, ChangedType changeType)
        {
            _name = project.Name;
            _type = changeType;
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

        public void UpdatePTasckCollection(IPTask task, IProject baseProject, ChangedType changeType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPTask> GetAllPTasks(bool onlyForActiveProject)
        {
            throw new NotImplementedException();
        }
    }
}
