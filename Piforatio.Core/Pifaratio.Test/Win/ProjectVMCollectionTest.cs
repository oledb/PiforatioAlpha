using NUnit.Framework;
using System;
using Moq;
using Piforatio.Win.ViewModel;
using Piforatio.Win.ViewModelCollection;
using Piforatio.Test.Core;
using Piforatio.Core.ObjectsAbstract;
using Piforatio.Core.DataModel;
using static Piforatio.Test.Core.FakeProjectFabrica;

namespace Piforatio.Test.Win
{
    [TestFixture]
    public class ProjectVMCollectionTest
    {
        IDataContextFactory factory;
        DataContextMock context;

        [TearDown]
        public void ClearFactoryAndContext()
        {
            factory = null;
            context = null;
        }

        [Test]
        public void ProjectsArrayIsNonNullOrEmpty()
        {
            //Arrange
            const int projectCollectionLength = 3;
            CreateFabricaAndMockContext(out factory, out context);
            var projectVMCollection = CreateProjectVMCollection(factory);

            //Act
            var projectCollection = projectVMCollection.Projects;

            //Assert
            Assert.IsNotNull(projectCollection);
            Assert.AreEqual(projectCollectionLength, projectCollection.Count);
        }

        [Test]
        public void SelectedProjectIsCorrected()
        {
            //Arrange
            CreateFabricaAndMockContext(out factory, out context);
            var projectVMCollection = CreateProjectVMCollection(factory);

            //Act
            var firstProject = projectVMCollection.Projects[0];
            projectVMCollection.SelectProjectByValue = firstProject.ProjectID;

            //Assert
            Assert.AreEqual(firstProject.Name, projectVMCollection.SelectedProject.Name);
            Assert.AreEqual(firstProject.CreationTime, projectVMCollection.SelectedProject.CreationTime);
        }

        [Test]
        public void AddNewProjectToProjectVMCollection()
        {
            //Arrange
            CreateFabricaAndMockContext(out factory, out context);
            var projectVMCollection = CreateProjectVMCollection(factory);
            IProject newProject = CreateProject("Asp.Net", new DateTime(2017, 1, 30), 12);

            //Act
            projectVMCollection.AddProject(newProject);

            //Assert
            context.VerifyProject("Asp.Net", ChangedType.Add);
        }

        [Test]
        public void DeleteProjectFromProjectVMCollection()
        {
            //Arrange
            const int FirstProjectValue = 0;
            const int ProjectCountEq2 = 2;
            CreateFabricaAndMockContext(out factory, out context);
            var projectVMCollection = CreateProjectVMCollection(factory);

            //Act
            projectVMCollection.SelectProjectByValue = FirstProjectValue;
            projectVMCollection.RemoveSelectedProject();

            //Assert
            context.VerifyProject("MVC", ChangedType.Delete);
            Assert.AreEqual(ProjectCountEq2, projectVMCollection.Projects.Count);
        }

        [Test]
        public void ChangeSelectedProject()
        {
            //Arrange
            CreateFabricaAndMockContext(out factory, out context);
            var projectVMCollection = CreateProjectVMCollection(factory);
            projectVMCollection.SelectProjectByValue = 0;

            //Act
            projectVMCollection.SelectedProject.Name = "Asp.Net";
            projectVMCollection.SaveSelectedProjectChange();

            //Assert
            context.VerifyProject("Asp.Net", ChangedType.Modify);
        }

        public static ProjectVMCollection CreateProjectVMCollection()
        {
            IDataContextFactory context = CreateDataContextFabricaMock();
            return CreateProjectVMCollection(context);
        }

        public static ProjectVMCollection CreateProjectVMCollection(IDataContextFactory context)
        {
            var projectModel = new ProjectModel(context);
            var projectVMCollection = new ProjectVMCollection(projectModel);
            return projectVMCollection;
        }
    }
}
