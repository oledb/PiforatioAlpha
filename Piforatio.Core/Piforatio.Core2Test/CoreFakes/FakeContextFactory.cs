using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using Effort;
using Piforatio.Core2;

namespace Piforatio.Core2Test
{
    public class FakeContextFactory : IContextFactory
    {
        private static DbConnection _connection;
        private static long _index = DateTime.Now.Ticks;
        private static readonly string Conn = $@"Data Source=(LocalDb)\v11.0;Integrated Security=SSPI;AttachDBFilename=D:\db\Test{_index}.mdf";

        public static void CreateDb()
        {
            _connection = Created();
        }

        private static DbConnection Created()
        {
            return DbConnectionFactory.CreatePersistent(_index++.ToString());
        }

        private static DbConnection Created2()
        {
            var connection = new SqlConnection(Conn);
            return connection;
        }

        static FakeContextFactory()
        {
            CreateDb();
        }

        public PiforatioContext Create()
        {
            var context = new PiforatioContext(_connection);
            //var context = new PiforatioContext(Created2());
            context.Database.CreateIfNotExists();
            context.Database.Log = Write;
            return context;
        }

        private static void Write(string value)
        {
            Debug.Write(value, "SQL Output");
        }
    }
}