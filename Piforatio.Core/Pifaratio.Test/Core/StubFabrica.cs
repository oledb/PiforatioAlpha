using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Piforatio.Core.ObjectsAbstract;
using Moq;

namespace Piforatio.Test.Core
{
    public static class StubFabrica
    {
        public static IProject CreateProject(string name, DateTime time, int index)
        {
            var mock = new Mock<IProject>();
            mock.Setup(p => p.Name).Returns(name);
            mock.Setup(p => p.CreationTime).Returns(time);
            mock.Setup(p => p.ProjectID).Returns(index);
            return mock.Object;
        }
    }
}
