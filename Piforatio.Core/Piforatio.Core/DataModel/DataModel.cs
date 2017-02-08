using System;
using System.Collections.ObjectModel;
using Piforatio.Core.DataModel;
using Piforatio.Core.ObjectsAbstract;

namespace Piforatio.Core.DataModel
{
    public abstract class DataModel<T> : IDataModel<T> where T : ICoreObject
    {
        protected IDataContextFactory dataContext;
        protected ObservableCollection<T> listObject;

        protected virtual void initDataModel(IDataContextFactory context)
        {
            dataContext = context;
            listObject = new ObservableCollection<T>();
            UpdateAll();
        }

        public DataModel(IDataContextFactory context)
        {
            initDataModel(context);
        }
        
        public abstract ObservableCollection<T> GetAllData();
        public abstract T GetData(int id);
        public abstract void Update(T obj, ChangedType type);
        public abstract void UpdateAll();
    }
}
