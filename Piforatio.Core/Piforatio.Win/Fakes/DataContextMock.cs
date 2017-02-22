using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Piforatio.Core.DataModel;
using Piforatio.Core.ObjectsAbstract;
using static Piforatio.Win.Fakes.FakeProjectFabrica;

namespace Piforatio.Win.Fakes
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
                yield return CreateProject("MVC", new DateTime(2017, 1, 20), index++, ProjectType.Study,
                    "Learn some basic MVC aspects.");
                yield return CreateProject("Point Theory", new DateTime(2017, 1, 10), index++, ProjectType.Work, 
                    "Create Piforatio xaml project and construct basic theory");
                yield return CreateProject("Xamarin", new DateTime(2017, 2, 1), index++, ProjectType.Study, 
                    "Learn Xamarin user interface designer and c# programming language");
            }
            else
                yield return null;
        }

        public void VerifyProject(string name, ChangedType changeType)
        {
            if (string.IsNullOrEmpty(_name) || _type == null)
                throw new Exception("Data was not be updated! Input data is null");

        }

        string _name;
        ChangedType? _type;
        public void UpdateProjectCollection(IProject project, ChangedType changeType)
        {
            _name = project.Name;
            _type = changeType;
        }

        public IEnumerable<IPTask> GetPTasks(IProject project)
        {
            throw new NotImplementedException();
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
