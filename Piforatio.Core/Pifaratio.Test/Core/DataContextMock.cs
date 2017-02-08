using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Piforatio.Core.DataModel;
using Piforatio.Core.ObjectsAbstract;

namespace Piforatio.Test.Core
{
    public class DataContextMock : IDataContext
    {
        static class DB
        {
            static List<IProject> list;
            static DB()
            {
                reset();
            }

            public static IEnumerable<IProject> get()
            {
                foreach (var p in list)
                    yield return p;
            }

            public static void set(IProject project)
            {
                foreach (var p in list)
                {
                    if (p.ProjectID == project.ProjectID)
                    {
                        p.Update(project);
                    }
                    list.Add(p);
                }
            }

            static void reset()
            {
                list = FakeProjectFabrica.CreateProjectList();
            }

        }

        public void Dispose()
        {
            
        }

        public IEnumerable<ICoreObject> GetData()
        {
            return DB.get();
        }

        public void UpdateCollection(IEnumerable<ICoreObject> obj)
        {
            throw new NotImplementedException();
        }

        public void UpdateEntry(ICoreObject obj)
        {
            DB.set((IProject)obj);
        }

        public int VerifyProjectByName(string name)
        {
            int count = 0;
            foreach(var p in DB.get())
            {
                if (string.Compare(p.Name, name) == 0)
                    count++;
            }
            return count;
        }
    }
}
