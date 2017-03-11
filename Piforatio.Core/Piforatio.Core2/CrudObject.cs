using System;
using System.Collections.Generic;
using System.Linq;

namespace Piforatio.Core2
{
    public abstract class CrudObject<T> where T : class
    {
        protected IContextFactory factory;
        internal CrudObject(IContextFactory contextFactory)
        {
            factory = contextFactory;
        }

        protected void useContext(Action<PiforatioContext> use)
        {
            using (var context = factory.Create())
            {
                use(context);
                context.SaveChanges();
            }
        }

        protected abstract void createObject(T obj, PiforatioContext context);
        protected abstract IEnumerable<T> readObject(Func<T, bool> isValid,
            PiforatioContext context);
        protected abstract void updateObject(T obj, PiforatioContext context);
        protected abstract void deleteObject(T obj, PiforatioContext context);

        public void Create(T obj)
        {
            using (var context = factory.Create())
            {
                createObject(obj, context);
                context.SaveChanges();
            }
        }

        public List<T> Read()
        {
            using (var context = factory.Create())
            {
                return readObject(o => true, context).ToList();
            }
        }

        public List<T> Read(Func<T, bool> isValid)
        {
            using (var context = factory.Create())
                return readObject(isValid, context).ToList();
        }

        public T ReadSingle(Func<T, bool> isValid)
        {
            using (var context = factory.Create())
                return readObject(isValid, context).SingleOrDefault();
        }

        public void Update(T obj)
        {
            using (var context = factory.Create())
            {
                updateObject(obj, context);
                context.SaveChanges();
            }
        }

        public void Delete(T obj)
        {
            using (var context = factory.Create())
            {
                deleteObject(obj, context);
                context.SaveChanges();
            }
        }
    }
}
