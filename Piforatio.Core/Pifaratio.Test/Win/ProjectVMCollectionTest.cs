using NUnit.Framework;
using System;
using Piforatio.Win.ViewModel;
using Piforatio.Win.ViewModelCollection;
using Piforatio.Test.Core;
using Piforatio.Core.ObjectsAbstract;
using Piforatio.Core.DataModel;

namespace Piforatio.Test.Win
{
    [TestFixture]
    public class ProjectVMCollectionTest
    {
        public static ProjectVMCollection CreateProjectVMCollection()
        {
            IDataContextFabrica context = FakeProjectFabrica.CreateDataContextFabricaMock();
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
            throw new NotImplementedException();
        }
    }
}
