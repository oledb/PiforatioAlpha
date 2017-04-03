using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Piforatio.Core2
{
    public abstract class EntityCollection<T> where T : class
    {
        protected IContextFactory Factory;
        internal EntityCollection(IContextFactory contextFactory)
        {
            Factory = contextFactory;
        }

        protected void UseContext(Action<PiforatioContext> use)
        {
            using (var context = Factory.Create())
            {
                use(context);
                context.SaveChanges();
            }
        }

        protected abstract void CreateObject(T obj, PiforatioContext context);
        protected abstract IEnumerable<T> ReadObject(Func<T, bool> pridicate,
            PiforatioContext context);
        protected abstract void UpdateObject(T obj, PiforatioContext context);
        protected abstract void DeleteObject(T obj, PiforatioContext context);

        public void Create(T obj)
        {
            using (var context = Factory.Create())
            {
                CreateObject(obj, context);
                context.Entry(obj).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public List<T> Read()
        {
            using (var context = Factory.Create())
            {
                return ReadObject(o => true, context).ToList();
            }
        }

        public List<T> Read(Func<T, bool> predicate)
        {
            using (var context = Factory.Create())
                return ReadObject(predicate, context).ToList();
        }

        public T ReadSingle(Func<T, bool> predicate)
        {
            using (var context = Factory.Create())
                return ReadObject(predicate, context).SingleOrDefault();
        }

        public void Update(T obj)
        {
            using (var context = Factory.Create())
            {
                UpdateObject(obj, context);
                context.Entry(obj).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(T obj)
        {
            using (var context = Factory.Create())
            {
                context.Entry(obj).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
