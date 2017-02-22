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

        [Test]
        public void CreatePTaskCollectionIsNotNull()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void ChangingValueIsChangeSelectedPTask()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void AddNewTaskToPTaskVMCollection()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void ChangePTaskInPTaskVMCollection()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void ChangeAimInPTask()
        {
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
