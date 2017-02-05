using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Piforatio.Core.DataModel;
using Piforatio.Core.ObjectsAbstract;
using Moq;

namespace Piforatio.Core.Test.Mocks
{
    public class ProjectModelMock : DataModel<IProject>
    {
        int _index;
        public ProjectModelMock()
        {
            _index = 0;
            listObject = new List<IProject>();
            this.listObject.AddRange(new IProject[]{
                GenerateProject("MVC", new DateTime(2017,1,20)),
                GenerateProject("Point Theory", new DateTime(2017,1,10)),
                GenerateProject("Xamarin", new DateTime(2017,2,1)),
            });
        }

        private IProject GenerateProject(string name, DateTime time)
        {
            var mock = new Mock<IProject>();
            mock.Setup(p => p.Name).Returns(name);
            mock.Setup(p => p.CreationTime).Returns(time);
            mock.Setup(p => p.ProjectID).Returns(_index++);
            return mock.Object;
        }

        public override IEnumerable<IProject> GetAllData()
        {
            return listObject;
        }

        public override IProject GetData(int id)
        {
            return (from p in listObject
                    where p.ProjectID == id
                    select p).SingleOrDefault();
        }

        public  PTaskModel GetPTaskModel(IProject project)
        {
            throw new NotImplementedException();
        }

        public override void Update(IProject obj)
        {
            throw new NotImplementedException();
        }

        public override void UpdateAll()
        {
            throw new NotImplementedException();
        }
    }
}
