using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Piforatio.Core.ObjectsAbstract;
using Piforatio.Core.DataModel;
using Moq;

namespace Piforatio.Test.Core
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

        public static List<IProject> CreateProjectList()
        {
            var listObject = new List<IProject>();
            CreateProjectList(listObject);
            return listObject;
        }

        public static void CreateProjectList(List<IProject> listObject)
        {
            int index = 0;

            listObject.AddRange(new IProject[]{
                CreateProject("MVC", new DateTime(2017,1,20), index++),
                CreateProject("Point Theory", new DateTime(2017,1,10), index++),
                CreateProject("Xamarin", new DateTime(2017,2,1), index++),
            });

        }

        public static IDataContextFabrica CreateDataContextFabricaMock()
        {
            var mock = new Mock<IDataContextFabrica>();
            mock.Setup(cf => cf.CreateContext()).Returns(CreateDataContextMock());
            return mock.Object;
        }

        public static IDataContextFabrica CreateDataContextFabricaStub()
        {
            var mock = new Mock<IDataContextFabrica>();
            var mockContext = new Mock<IDataContext>();
            mock.Setup(cf => cf.CreateContext()).Returns(mockContext.Object);
            return mock.Object;
        }

        public static IDataContext CreateDataContextMock()
        {
            var mock = new Mock<IDataContext>();
            mock.Setup(c => c.GetData()).Returns(CreateProjectList());
            return mock.Object;
        }
    }
}
