using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Moq;
using Piforatio.Core.ObjectsAbstract;
using Piforatio.Core.DataModel;
using static Piforatio.Test.Core.FakeProjectFabrica;

namespace Piforatio.Test.Core
{
    [TestFixture]
    public class ProjectModelTest
    {
        [Test]
        public void CreateAndSaveDataToModel()
        { 
            const int result_array_length = 1;
            var pm = new ProjectModel(CreateDataContextFabricaStub());
            var list = pm.GetAllData();

            list.Add(CreateProject("Test", new DateTime(2017, 1, 25), 0));
            pm.Update(list[0], ChangedType.Add);

            var result = pm.GetAllData();
            Assert.AreEqual(result_array_length, result.Count);
            Assert.AreEqual("Test", result[0].Name);
        }

        [Test]
        public void CreatedProjectListIsNotNull()
        {
            var pm = new ProjectModel(CreateDataContextFabricaMock());

            var list = pm.GetAllData();

            Assert.IsNotNull(list);
        }

        [Test]
        public void GetPTaskModelForFirstProject()
        {
            var pm = new ProjectModel(CreateDataContextFabricaMock());
            var list = pm.GetAllData();
            var firstProject = list[0];

            PTaskModel model = pm.GetPTaskModel(firstProject);

            Assert.AreEqual(firstProject.Name, model.BaseProject.Name);
            Assert.AreEqual(firstProject.CreationTime, model.BaseProject.CreationTime);

        }
    }
}
