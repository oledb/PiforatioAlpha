using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Piforatio.Core.ObjectsAbstract;

namespace Piforatio.Core.DataModel
{
    public interface IDataModel<T> where T : ICoreObject
    {
        T GetData(int id);
        List<T> GetAllData();
        void UpdateAll();
        void Update(T obj);
    }
}
