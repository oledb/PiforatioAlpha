using System;
using Piforatio.Core2;
using System.Data.Common;
using Effort;

namespace Piforatio.Core2Test
{
    public class FakeContextFactory : IContextFactory
    {
        static private DbConnection connection;

        static public void CreateDb()
        {
            connection = DbConnectionFactory.CreateTransient();
        }

        static FakeContextFactory()
        {
            CreateDb();
        }

        public PiforatioContext Create()
        {
            var context = new PiforatioContext(connection);
            context.Database.CreateIfNotExists();
            return context;
        }
    }
}
