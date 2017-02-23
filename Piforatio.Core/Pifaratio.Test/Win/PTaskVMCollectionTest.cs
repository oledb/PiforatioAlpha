using NUnit.Framework;
using System;
using System.Linq;
using Moq;
using Piforatio.Win.ViewModel;
using Piforatio.Win.ViewModelCollection;
using Piforatio.Test.Core;
using Piforatio.Core.ObjectsAbstract;
using Piforatio.Core.DataModel;
using static Piforatio.Test.Core.FakesFabrica;

namespace Piforatio.Test.Win
{
    [TestFixture]
    class PTaskVMCollectionTest
    {
        private ProjectVMCollection fakeProjectVMC = null;
        const int firstProjectValue = 0;
        [Test]
        public void CreatePTaskCollectionIsNotNull()
        {
            //Arrange
            fakeProjectVMC = CreatFakeProjectVMCollection();
            fakeProjectVMC.SelectProjectByValue = firstProjectValue;

            //Act
            var PTaskVMC = fakeProjectVMC.CreatePTaskVMCollection();

            //Assert
            Assert.IsNotNull(PTaskVMC);
            Assert.IsNotNull(PTaskVMC.PTasks);
        }

        [Test]
        public void ChangingValueIsChangeSelectedPTask()
        {
            //Arrange
            fakeProjectVMC = CreatFakeProjectVMCollection();
            fakeProjectVMC.SelectProjectByValue = firstProjectValue;
            var PTaskVMC = fakeProjectVMC.CreatePTaskVMCollection();

            //Act
            PTaskVMC.SelectPTaskByValue = 0;
            var firstPTaskDescription = PTaskVMC?.SelectedPTask?.Desctiption;
            PTaskVMC.SelectPTaskByValue = 1;
            var secondPTaskDescription = PTaskVMC?.SelectedPTask?.Desctiption;

            //Assert
            Assert.IsNotNull(PTaskVMC.PTasks);
            Assert.IsTrue(PTaskVMC.PTasks.Count > 1);
            Assert.AreEqual(PTaskVMC.PTasks[0].Desctiption, firstPTaskDescription);
            Assert.AreEqual(PTaskVMC.PTasks[1].Desctiption, secondPTaskDescription);
        }

        [Test]
        public void AddNewTaskToPTaskVMCollection()
        {
            //Arrange
            DataContextMock context;
            fakeProjectVMC = CreatFakeProjectVMCollection(out context);
            fakeProjectVMC.SelectProjectByValue = firstProjectValue;
            var PTaskVMC = fakeProjectVMC.CreatePTaskVMCollection();
            const int TestPTaskID = 43563;
            var newPTask = CreatePTask(PTaskVMC.BaseProject, "Test PTask", TestPTaskID);

            //Act
            PTaskVMC.AddPTask(newPTask);
            var findPTask = PTaskVMC.PTasks.Where(t => t.TaskID == TestPTaskID)
                                           .SingleOrDefault();

            //Assert
            Assert.IsNotNull(findPTask);
            Assert.AreEqual(TestPTaskID, findPTask.TaskID);
            context.VerifyPTask( (task, baseTask, changeType) =>
           {
               return (task.TaskID == TestPTaskID) && changeType == ChangedType.Add;
           });
        }

        [Test]
        public void ChangePTaskInPTaskVMCollection()
        {
            //Arrange
            const string TestPTaskDescription = "Test PTask new";
            DataContextMock context;
            fakeProjectVMC = CreatFakeProjectVMCollection(out context);
            fakeProjectVMC.SelectProjectByValue = firstProjectValue;
            var PTaskVMC = fakeProjectVMC.CreatePTaskVMCollection();
            PTaskVMC.SelectPTaskByValue = 0;

            //Act
            PTaskVMC.SelectedPTask.Desctiption = TestPTaskDescription;
            PTaskVMC.ChangePTaskSelected();

            //Assert
            context.VerifyPTask((task, baseTask, changeType) =>
            {
                return (task.Desctiption == TestPTaskDescription) && changeType == ChangedType.Modify;
            });
        }

        [Test]
        public void AddAimToSelectedPTask()
        {
            //Arrange

            //Act

            //Assert
            throw new NotImplementedException();
        }

        [Test]
        public void RemovePTaskInPTaskVMCollection()
        {
            //Arrange

            //Act

            //Assert
            throw new NotImplementedException();
        }

        [TearDown]
        public void ClearData()
        {
            fakeProjectVMC = null;
        }

        public ProjectVMCollection CreatFakeProjectVMCollection()
        {
            DataContextMock context;
            return CreatFakeProjectVMCollection(out context);
        }

        public ProjectVMCollection CreatFakeProjectVMCollection(out DataContextMock context)
        {
            IDataContextFactory factory;
            CreateFabricaAndMockContext(out factory, out context);
            IProject project = CreateProject("MVC", new DateTime(), 0);
            PTaskModel model = new PTaskModel(factory, project);
            var mock = new Mock<ProjectVMCollection>();
            PTaskVMCollection taskCollection = new PTaskVMCollection(model);
            mock.Setup(c => c.CreatePTaskVMCollection()).Returns(taskCollection);
            return mock.Object;
        }
    }
}
