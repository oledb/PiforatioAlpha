using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Piforatio.Core.ObjectsAbstract;

namespace Piforatio.Core.DataModel
{
    public class ProjectModel : DataModel<IProject>
    {
        public ProjectModel(IDataContext context) : base(context)
        { }

        public override List<IProject> GetAllData()
        {
            return listObject;
        }

        public override IProject GetData(int id)
        {
            return (from p in listObject
                    where p.ProjectID == id
                    select p).SingleOrDefault();
        }

        public override void Update(IProject obj)
        {
            //save data to file, db or something
            throw new NotImplementedException();
        }

        public override void UpdateAll()
        {
            //save data to file, db or something
            throw new NotImplementedException();
        }
    }
}
