using System;
using System.Collections.ObjectModel;
using Piforatio.Core.ObjectsAbstract;

namespace Piforatio.Core.DataModel
{
    /// <summary>
    /// <see cref="DataModel{T}"/> will be using as base class for all *Model classes
    /// This class has not been used yet
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class DataModel<T>  where T : ICoreObject
    {
        protected IDataContextFactory dataContext;
        protected ObservableCollection<T> listObject;

        protected virtual void initDataModel(IDataContextFactory context)
        {
            dataContext = context;
            listObject = new ObservableCollection<T>();
            //UpdateAll();
        }

        public DataModel(IDataContextFactory context)
        {
            initDataModel(context);
        }
        
        public abstract ObservableCollection<T> GetAllData();
        public abstract T GetData(int id);
        public abstract void Update(T obj, ChangedType type);
        public abstract void Load();
    }


}
