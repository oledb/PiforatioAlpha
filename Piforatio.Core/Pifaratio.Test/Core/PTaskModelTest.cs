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

            //Act

            //Assert

            throw new NotImplementedException();
        }

        [Test]
        public void CreateAndSavePTask()
        {
            //Arrange
            IDataContextFactory factory = CreateDataContextFabricaStub();
            IProject project = CreateProject("Test Project", new DateTime(2017, 1, 20), 34);
            PTaskModel model = new PTaskModel(factory, null);

            //Act

            //Assert
            throw new NotImplementedException();
        }
    }
}
