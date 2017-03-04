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
        [Test]
        public void SaveDataToModel()
        {
            //Arrange
            Mock<IDataContext> dataContext;
            var projectModel = new ProjectModel(CreateFakeDataContextFabrica(out dataContext));
            projectModel.Load();
            var newProject = CreateProject("Test project");

            //Act
            projectModel.Update(newProject, ChangedType.Add);
            
            //Assert
            dataContext.Verify(context => 
                context.UpdateProject(newProject, ChangedType.Add));
        }

        [Test]
        public void CreatedProjectListIsNotNull()
        {
            //Arrange
            var projectModel = new ProjectModel(CreateFakeDataContextFabrica());

            //Act
            var list = projectModel.GetAllProjects();

            //Assert
            Assert.IsNotNull(list);
        }

        [Test]
        public void GetPTaskModelForFirstProject()
        {
            //Arrange
            var projectModel = new ProjectModel(CreateFakeDataContextFabrica());
            projectModel.Load();
            var list = projectModel.GetAllProjects();
            var firstProject = list.Take(1).SingleOrDefault();

            //Act
            PTaskModel model = projectModel.GetPTaskModel(firstProject);

            //Assert
            Assert.AreEqual(firstProject.Name, model.BaseProject.Name);
            Assert.AreEqual(firstProject.CreationTime, model.BaseProject.CreationTime);

        }

        public static IDataContextFactory CreateFakeDataContextFabrica()
        {
            Mock<IDataContext> mockContext;
            return CreateFakeDataContextFabrica(out mockContext);
        }

        public static IDataContextFactory CreateFakeDataContextFabrica(out Mock<IDataContext> mockDataContext)
        {
            var mock = new Mock<IDataContextFactory>();
            mockDataContext = new Mock<IDataContext>();
            mockDataContext.Setup(dc => dc.GetProjects())
                       .Returns(new List<IProject>() { CreateProject("Test from fake database") });
            mock.Setup(cf => cf.CreateContext()).Returns(mockDataContext.Object);
            return mock.Object;
        }

        public static IProject CreateProject(string name)
        {
            var mock = new Mock<IProject>();
            mock.Setup(p => p.Name).Returns(name);
            return mock.Object;
        }
    }
}
