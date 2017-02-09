using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Piforatio.Core.DataModel;
using Piforatio.Core.ObjectsAbstract;
using static Piforatio.Test.Core.FakeProjectFabrica;

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

        public IEnumerable<IPTask> GetPTaskAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPTask> GetPTask(IProject project)
        {
            throw new NotImplementedException();
        }

        public void UpdatePTasckCollection(IPTask task, IProject baseProject, ChangedType changeType)
        {
            throw new NotImplementedException();
        }
    }
}
