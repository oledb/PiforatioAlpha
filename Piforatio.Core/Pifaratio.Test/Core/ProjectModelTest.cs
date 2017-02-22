using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Moq;
using Piforatio.Core.ObjectsAbstract;
using Piforatio.Core.DataModel;
using static Piforatio.Test.Core.FakesFabrica;

namespace Piforatio.Test.Core
{
    [TestFixture]
    public class ProjectModelTest
    {
        [Test]
        public void CreateAndSaveDataToModel()
        {
            //Arrange
            const int result_array_length = 1;
            var projectModel = new ProjectModel(CreateDataContextFabricaStub());
            projectModel.Load();
            var list = projectModel.GetAllProjects();
            var list2 = projectModel.GetAllProjects();

            //Act
            list.Add(CreateProject("Test", new DateTime(2017, 1, 25), 0));
            projectModel.Update(list[0], ChangedType.Add);

            //Assert
            var result = projectModel.GetAllProjects();
            Assert.AreEqual(result_array_length, result.Count);
            Assert.AreEqual("Test", result[0].Name);
        }

        [Test]
        public void CreatedProjectListIsNotNull()
        {
            var projectModel = new ProjectModel(CreateDataContextFabricaMock());

            var list = projectModel.GetAllProjects();

            Assert.IsNotNull(list);
        }

        [Test]
        public void GetPTaskModelForFirstProject()
        {
            var projectModel = new ProjectModel(CreateDataContextFabricaMock());
            projectModel.Load();
            var list = projectModel.GetAllProjects();
            var firstProject = list[0];

            PTaskModel model = projectModel.GetPTaskModel(firstProject);

            Assert.AreEqual(firstProject.Name, model.BaseProject.Name);
            Assert.AreEqual(firstProject.CreationTime, model.BaseProject.CreationTime);

        }
    }
}
