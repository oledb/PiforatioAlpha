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
            const int projectCollectionLength = 3;
            CreateFabricaAndMockContext(out factory, out context);
            var pvmc = CreateProjectVMCollection(factory);

            var projectCollection = pvmc.Projects;

            Assert.IsNotNull(projectCollection);
            Assert.AreEqual(projectCollectionLength, projectCollection.Count);
        }

        [Test]
        public void SelectedProjectIsCorrected()
        {
            CreateFabricaAndMockContext(out factory, out context);
            var pvmc = CreateProjectVMCollection(factory);

            var firstProject = pvmc.Projects[0];
            pvmc.SelectProjectByID = firstProject.ProjectID;

            Assert.AreEqual(firstProject.Name, pvmc.SelectedProject.Name);
            Assert.AreEqual(firstProject.CreationTime, pvmc.SelectedProject.CreationTime);
        }

        [Test]
        public void AddNewProjectToProjectVMCollection()
        {
            CreateFabricaAndMockContext(out factory, out context);
            var pvmc = CreateProjectVMCollection(factory);

            pvmc.Projects.Add(CreateProject("Asp.Net", new DateTime(2017, 1, 30), 12));

            context.VerifyProject("Asp.Net", ChangedType.Add);
        }

        [Test]
        public void DeleteProjectFromProjectVMCollection()
        {
            CreateFabricaAndMockContext(out factory, out context);
            var pvmc = CreateProjectVMCollection(factory);

            pvmc.Projects.RemoveAt(0);

            context.VerifyProject("MVC", ChangedType.Delete);
        }

        [Test]
        public void ChangeSelectedProject()
        {
            CreateFabricaAndMockContext(out factory, out context);
            var pvmc = CreateProjectVMCollection(factory);
            pvmc.SelectProjectByID = 0;

            pvmc.SelectedProject.Name = "Asp.Net";

            context.VerifyProject("Asp.Net", ChangedType.Modify);
        }
    }
}
