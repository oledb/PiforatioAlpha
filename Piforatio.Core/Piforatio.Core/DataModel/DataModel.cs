using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Piforatio.Core.ObjectsAbstract;

namespace Piforatio.Core.DataModel
{
    public abstract class DataModel<T> : IDataModel<T> where T : ICoreObject
    {
        protected IDataContext dataContext;
        protected virtual void initDataModel(IDataContext context)
        {
            dataContext = context;
            listObject = new List<T>();
        }

        public DataModel(IDataContext context)
        {
            initDataModel(context);
        }
        protected List<T> listObject;
        public abstract List<T> GetAllData();
        public abstract T GetData(int id);
        public abstract void Update(T obj);
        public abstract void UpdateAll();
    }
}
