using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Piforatio.Core.ObjectsAbstract;

namespace Piforatio.Core.DataModel
{
    public abstract class DataModel<T> : IDataModel<T> where T : ICoreObject
    {
        protected IDataContextFabrica dataContext;
        protected ObservableCollection<T> listObject;

        protected virtual void initDataModel(IDataContextFabrica context)
        {
            dataContext = context;
            listObject = new ObservableCollection<T>();
        }

        public DataModel(IDataContextFabrica context)
        {
            initDataModel(context);
        }
        
        public abstract ObservableCollection<T> GetAllData();
        public abstract T GetData(int id);
        public abstract void Update(T obj);
        public abstract void UpdateAll();
    }
}
