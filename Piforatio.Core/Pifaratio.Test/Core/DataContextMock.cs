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
        static class DB
        {
            static List<IProject> list;
            static DB()
            {
                reset();
            }

            public static IEnumerable<IProject> get()
            {
                foreach (var p in list)
                    yield return p;
            }

            public static void set(IProject project)
            {
                foreach (var p in list)
                {
                    if (p.ProjectID == project.ProjectID)
                    {
                        p.Update(project);
                    }
                    list.Add(p);
                }
            }

            static void reset()
            {
                list = FakeProjectFabrica.CreateProjectList();
            }

        }

        public void Dispose()
        {
            
        }

        public void UpdateCollection(IEnumerable<ICoreObject> obj)
        {
            throw new NotImplementedException();
        }

        public void UpdateEntry(ICoreObject obj)
        {
            DB.set((IProject)obj);
        }

        public int VerifyProjectByName(string name)
        {
            int count = 0;
            foreach(var p in DB.get())
            {
                if (string.Compare(p.Name, name) == 0)
                    count++;
            }
            return count;
        }

        public IEnumerable<IProject> GetProjects()
        {
            int index = 0;
            yield return CreateProject("MVC", new DateTime(2017, 1, 20), index++);
            yield return CreateProject("Point Theory", new DateTime(2017, 1, 10), index++);
            yield return CreateProject("Xamarin", new DateTime(2017, 2, 1), index++);
        }

        public void VerifyProjectNameAndUpdateType(string name, ChangedType changeType)
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
