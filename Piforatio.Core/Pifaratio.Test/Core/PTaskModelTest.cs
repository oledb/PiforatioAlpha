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
    public class PTaskModelTest
    {
        [Test]
        public void CreateAndSavePTask_Failed()
        {
            //Arrange
            IDataContextFactory factory = CreateDataContextFabricaStub();
            PTaskModel model = new PTaskModel(factory, null);
            IPTask ptask = CreatePTask(null, "Test", 100);

            //Act, Assert
            Assert.Catch<NullReferenceException>(() => { model.Update(ptask, ChangedType.Add); });
        }

        [Test]
        public void CreateAndSavePTask()
        {
            //Arrange
            const int pTaskIndex = 215;
            const int projectIndex = 1345;
            DataContextMock context;
            IDataContextFactory factory;
            CreateFabricaAndMockContext(out factory, out context);
            IProject project = CreateProject("Test Project", new DateTime(2017, 1, 20), projectIndex);
            PTaskModel model = new PTaskModel(factory, project);
            IPTask ptask = CreatePTask(project, "Test ptask", pTaskIndex);

            //Act
            model.Update(ptask, ChangedType.Add);
            IPTask firstPTask = model.GetTasks().Take(1).SingleOrDefault();

            //Assert
            Assert.IsNotNull(firstPTask);
            Assert.IsNotNull(firstPTask.BaseProject);
            Assert.AreEqual(pTaskIndex, firstPTask.TaskID);
            Assert.AreEqual(projectIndex, firstPTask.BaseProject.ProjectID);
        }
    }
}
