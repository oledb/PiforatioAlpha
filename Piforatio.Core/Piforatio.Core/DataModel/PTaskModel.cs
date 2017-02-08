﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Piforatio.Core.ObjectsAbstract;
using Moq;

namespace Piforatio.Core.DataModel
{
    public class PTaskModel : DataModel<IPTask>
    {
        public PTaskModel(IDataContext context, IProject project) : base(context) { }

        public IProject BaseProject { get; protected set; }

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
