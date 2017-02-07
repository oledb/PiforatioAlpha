using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Moq;
using Piforatio.Core.ObjectsAbstract;
using Piforatio.Core.DataModel;
using Piforatio.Core.Test.Mocks;

namespace Piforatio.Test.Core
{
    [TestFixture]
    public class ProjectModelTest
    {
        [Test]
        public void Create_success()
        {
            ProjectModel pm = new ProjectModelMock();
            var list = new List<IProject>();
            list = (List<IProject>)pm.GetAllData();
            list.RemoveAll(p => true);
            

            foreach (var p in pm.GetAllData())
            {
                throw new Exception("Data was not removed! " + p.Name);
            }
        }

        [Test]
        public void ctor_LitNotNull()
        {
            var pm = new ProjectModel
        }
    }
}
