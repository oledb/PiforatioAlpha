using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Piforatio.Core.ObjectsAbstract;
using Piforatio.Core.DataModel;

namespace Piforatio.Core.DataModel
{
    public class ModelEntityEventArgs : EventArgs
    {
        public ICoreObject ChangingObject { get; private set; }
        public ChangedType Type { get; private set; }
        public ModelEntityEventArgs(ICoreObject obj, ChangedType type)
        {
            ChangingObject = obj;
            Type = type;
        }
    }
}
