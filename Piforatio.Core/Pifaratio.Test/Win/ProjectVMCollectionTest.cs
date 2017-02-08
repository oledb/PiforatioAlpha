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
            IDataContextFabrica context = CreateDataContextFabricaMock();
            return CreateProjectVMCollection(context);
        }

        public static ProjectVMCollection CreateProjectVMCollection(IDataContextFabrica context)
        {
            var pm = new ProjectModel(context);
            var pvmc = new ProjectVMCollection(pm);
            return pvmc;
        }

        [Test]
        public void ProjectsIsNonNullOrEmpty()
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
        public void ChangeSelectedProjectAndSave()
        {
            const int Only_One = 1;
            var mockFabrica = new Mock<IDataContextFabrica>();
            var mockContext = new DataContextMock();
            mockFabrica.Setup(cf => cf.CreateContext()).Returns(mockContext);

            var pvmc = CreateProjectVMCollection(mockFabrica.Object);
            var firstProject = pvmc.Projects[0];
            pvmc.SelectProjectByID = firstProject.ProjectID;

            pvmc.SelectedProject.Name = "Asp.Net Forms";

            var count = mockContext.VerifyProjectByName("Asp.Net Forms");

            Assert.AreEqual(Only_One, count);
        }
    }
}
