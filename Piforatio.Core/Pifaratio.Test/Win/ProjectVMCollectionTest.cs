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
            var pm = new ProjectModel(context);
            var pvmc = new ProjectVMCollection(pm);
            return pvmc;
        }

        [Test]
        public void ProjectsArrayIsNonNullOrEmpty()
        {
            const int projectCollectionLength = 3;
            var pvmc = CreateProjectVMCollection();

            var projectCollection = pvmc.Projects;

            Assert.IsNotNull(projectCollection);
            Assert.AreEqual(projectCollectionLength, projectCollection.Count);
        }

        [Test]
        public void SelectedProjectIsCorrected()
        {
            var pvmc = CreateProjectVMCollection();

            var firstProject = pvmc.Projects[0];
            pvmc.SelectProjectByID = firstProject.ProjectID;

            Assert.AreEqual(firstProject.Name, pvmc.SelectedProject.Name);
            Assert.AreEqual(firstProject.CreationTime, pvmc.SelectedProject.CreationTime);
        }

        [Test]
        public void AddNewProjectToProjectVMCollection()
        {
            IDataContextFactory factory;
            DataContextMock context;
            CreateFabricaAndMockContext(out factory, out context);

            var pvmc = CreateProjectVMCollection(factory);

            pvmc.Projects.Add(CreateProject("Asp.Net", new DateTime(2017, 1, 30), 12));

            context.VerifyProjectNameAndUpdateType("Asp.Net", ChangedType.Add);
        }
    }
}
