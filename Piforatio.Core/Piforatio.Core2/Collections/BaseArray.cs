using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

namespace Piforatio.Core2
{
    public abstract class BaseArray<T> where T : ICoreObject
    {
        protected List<T> list;

        public BaseArray()
        {
            list = new List<T>();
        }

        public void Add(T obj)
        {
            list.Add(obj);
        }

        public List<T> Get(Func<T, bool> isValid)
        {
            var result = (from o in list
                          where isValid(o)
                          select o).ToList();
            return result;
        }

        public int Length
        {
            get { return list.Count; }
        }

        public void Update(T obj)
        {
            var oldObj = list.Find(o => obj.ID == o.ID);
            oldObj.Update(obj);
        }

        public void Update(int id, T obj)
        {
            obj.ID = id;
            Update(obj);
        }
    }
}
