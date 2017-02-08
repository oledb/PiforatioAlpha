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
        public void ctor_ProjectsNotNullOrEmpty()
        {
            const int projectCollectionLength = 3;
            var pvmc = CreateProjectVMCollection();

            var projectCollection = pvmc.Projects;

            Assert.IsNotNull(projectCollection);
            Assert.AreEqual(projectCollectionLength, projectCollection.Count);
        }

        [Test]
        public void SelectProject_NotNullOrEmpty()
        {
            var pvmc = CreateProjectVMCollection();

            var firstProject = pvmc.Projects[0];
            pvmc.SelectProjectByID = firstProject.ProjectID;

            Assert.AreEqual(firstProject.Name, pvmc.SelectedProject.Name);
            Assert.AreEqual(firstProject.CreationTime, pvmc.SelectedProject.CreationTime);
        }

        [Test]
        public void UpdateData_success()
        {
            var mockFabrica = new Mock<IDataContextFabrica>();
            var mockContext = new Mock<IDataContext>();
            mockContext.Setup(c => c.UpdateEntry(CreateProject("Asp.Net Forms", default(DateTime),0)));
            mockFabrica.Setup(cf => cf.CreateContext()).Returns(mockContext.Object);

            var pvmc = CreateProjectVMCollection(mockFabrica.Object);
            var firstProject = pvmc.Projects[0];
            pvmc.SelectProjectByID = firstProject.ProjectID;

            pvmc.SelectedProject.Name = "Asp.Net Forms";

            throw new NotImplementedException("Can not verify mock input data");
        }
    }
}
