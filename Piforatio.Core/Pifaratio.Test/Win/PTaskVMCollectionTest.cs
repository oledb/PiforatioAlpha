using NUnit.Framework;
using System;
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
            fakeProjectVMC = CreatFakeProjectVMCollection();
            fakeProjectVMC.SelectProjectByValue = firstProjectValue;
            var PTaskVMC = fakeProjectVMC.CreatePTaskVMCollection();
            const int TestPTaskID = 43563;
            var newPTask = CreatePTask(PTaskVMC.BaseProject, "Test PTask", TestPTaskID);

            //Act
            

            //Assert
            throw new NotImplementedException();
        }

        [Test]
        public void ChangePTaskInPTaskVMCollection()
        {
            //Arrange

            //Act

            //Assert
            throw new NotImplementedException();
        }

        [Test]
        public void ChangeAimInPTask()
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
            return null;
        }

        public ProjectVMCollection CreatFakeProjectVMCollection(out DataContextMock context)
        {
            context = null;
            return CreatFakeProjectVMCollection();
        }
    }
}
