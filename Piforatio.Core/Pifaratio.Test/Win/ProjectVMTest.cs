using NUnit.Framework;
using System;
using Piforatio.Win.ViewModel;
using Piforatio.Test.Core;
using Piforatio.Core.ObjectsAbstract;

namespace Piforatio.Test.Win
{
    [TestFixture]
    class ProjectVMTest
    {
        [Test]
        public void Update_dataNotEmpty()
        {
            var pvm = new ProjectVM();
            var project = FakesFabrica.CreateProject("MVC", new DateTime(2017, 1, 30), 34);

            pvm.Update(project);

            Assert.AreEqual(project.Name, pvm.Name);
            Assert.AreEqual(project.CreationTime, pvm.CreationTime);
            Assert.AreEqual(project.ProjectID, pvm.ProjectID);
        }

        [Test]
        public void ctor_dataNotEmpty()
        {
            var project = FakesFabrica.CreateProject("MVC", new DateTime(2017, 1, 30), 34);

            var pvm = new ProjectVM(project);

            Assert.AreEqual(project.Name, pvm.Name);
            Assert.AreEqual(project.CreationTime, pvm.CreationTime);
            Assert.AreEqual(project.ProjectID, pvm.ProjectID);
        }
    }
}
