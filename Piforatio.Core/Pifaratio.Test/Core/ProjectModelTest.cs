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
            CreateProjectList(listObject);
            return listObject;
        }

        public static void CreateProjectList(List<IProject> listObject)
        {
            int index = 0;
            
            listObject.AddRange(new IProject[]{
                CreateProject("MVC", new DateTime(2017,1,20), index++),
                CreateProject("Point Theory", new DateTime(2017,1,10), index++),
                CreateProject("Xamarin", new DateTime(2017,2,1), index++),
            });
            
        }

        public static IProject CreateProject(string name, DateTime time, int index)
        {
            var mock = new Mock<IProject>();
            mock.Setup(p => p.Name).Returns(name);
            mock.Setup(p => p.CreationTime).Returns(time);
            mock.Setup(p => p.ProjectID).Returns(index);
            return mock.Object;
        }

        public static IDataContext CreateDataContext()
        {
            var mock = new Mock<IDataContext>();
            return mock.Object;
        }

        [Test]
        public void GetAllData_success()
        { 
            const int result_array_length = 1;
            var pm = new ProjectModel(CreateDataContext());
            var list = pm.GetAllData();

            list.Add(CreateProject("Test", new DateTime(2017, 1, 25), 0));

            var result = pm.GetAllData();
            Assert.AreEqual(result_array_length, result.Count);
            Assert.AreEqual("Test", result[0].Name);
        }

        [Test]
        public void ctor_LitIsNotNull()
        {
            var pm = new ProjectModel(CreateDataContext());

            var list = pm.GetAllData();

            Assert.IsNotNull(list);
        }

        [Test]
        public void GetPTaskModel_get()
        {
            var pm = new ProjectModel(CreateDataContext());
            var list = pm.GetAllData();
            CreateProjectList(list);
            var firstProject = list[0];
            PTaskModel model = pm.GetPTaskModel(firstProject);

            Assert.AreEqual(firstProject, model.BaseProject);

        }
    }
}
