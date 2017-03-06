using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piforatio.Core2
{
    public abstract class BaseArray<T> 
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

        public int Length
        {
            get { return list.Count; }
        }
    }
}
