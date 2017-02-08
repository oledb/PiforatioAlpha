using System;
using System.Collections.Generic;
using Piforatio.Core.ObjectsAbstract;

namespace Piforatio.Core.DataModel
{
    public interface IDataContext : IDisposable
    {
        IEnumerable<ICoreObject> GetData();
        void UpdateEntry(ICoreObject obj);
        void UpdateCollection(IEnumerable<ICoreObject> obj);
    }
}
