using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Piforatio.Core.ObjectsAbstract;
using Piforatio.Core.DataModel;
using Moq;

namespace Piforatio.Win.Fakes
{
    public static class FakeProjectFabrica
    {
        public static IProject CreateProject(string name, DateTime time, int index)
        {
            var mock = new Mock<IProject>();
            mock.Setup(p => p.Name).Returns(name);
            mock.Setup(p => p.CreationTime).Returns(time);
            mock.Setup(p => p.ProjectID).Returns(index);
            return mock.Object;
        }
        

        public static IDataContextFactory CreateDataContextFabricaMock()
        {
            var mock = new Mock<IDataContextFactory>();
            mock.Setup(cf => cf.CreateContext()).Returns(new DataContextMock());
            return mock.Object;
        }

        public static IDataContextFactory CreateDataContextFabricaStub()
        {
            var mock = new Mock<IDataContextFactory>();
            var mockContext = new Mock<IDataContext>();
            mock.Setup(cf => cf.CreateContext()).Returns(mockContext.Object);
            return mock.Object;
        }

        public static void CreateFabricaAndMockContext(out IDataContextFactory contextFactory, out DataContextMock contextMock)
        {
            var mock = new Mock<IDataContextFactory>();
            contextMock = new DataContextMock();
            mock.Setup(cf => cf.CreateContext()).Returns(contextMock);
            contextFactory = mock.Object;

        }

       
    }
}
