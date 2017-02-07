using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Moq;
using Piforatio.Core.ObjectsAbstract;
using Piforatio.Core.DataModel;

namespace Piforatio.Test.Core
{
    [TestFixture]
    public class ProjectModelTest
    {
        public static List<IProject> CreateProjectList()
        {
            var listObject = new List<IProject>();
            listObject.AddRange(new IProject[]{
                GenerateProject("MVC", new DateTime(2017,1,20)),
                GenerateProject("Point Theory", new DateTime(2017,1,10)),
                GenerateProject("Xamarin", new DateTime(2017,2,1)),
            });
            return listObject;
        }

        public static IProject GenerateProject(string name, DateTime time)
        {
            int _index = 0;
            var mock = new Mock<IProject>();
            mock.Setup(p => p.Name).Returns(name);
            mock.Setup(p => p.CreationTime).Returns(time);
            mock.Setup(p => p.ProjectID).Returns(_index++);
            return mock.Object;
        }

        [Test]
        public void Create_success()
        {
            ProjectModel pm = new ProjectModel();
            var list = new List<IProject>();
            list = (List<IProject>)pm.GetAllData();
            list.RemoveAll(p => true);
            

            foreach (var p in pm.GetAllData())
            {
                throw new Exception("Data was not removed! " + p.Name);
            }
        }

        [Test]
        public void ctor_LitNotNull()
        {
            var pm = new ProjectModel();
        }
    }
}
