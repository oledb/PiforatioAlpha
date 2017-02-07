using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Piforatio.Core.ObjectsAbstract;

namespace Piforatio.Core.DataModel
{
    public class PTaskModel : DataModel<IPTask>
    {
        public PTaskModel(IDataContext context) : base(context) { }

        public IProject BaseProject { get; }

        public override List<IPTask> GetAllData()
        {
            throw new NotImplementedException();
        }

        public override IPTask GetData(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(IPTask obj)
        {
            throw new NotImplementedException();
        }

        public override void UpdateAll()
        {
            throw new NotImplementedException();
        }
    }
}
