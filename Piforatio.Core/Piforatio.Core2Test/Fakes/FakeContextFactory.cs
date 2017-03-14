using Effort;
using Piforatio.Core2;
using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Piforatio.Core2Test
{
    public class FakeContextFactory : IContextFactory
    {
        static private DbConnection connection;
        static long index = DateTime.Now.Ticks;
        static string conn = $@"Data Source=(LocalDb)\v11.0;
        Integrated Security=SSPI;
        AttachDBFilename=D:\db\Test{index}.mdf";

        static public void CreateDb()
        {
            connection = Created();
        }

        static DbConnection Created()
        {
            return DbConnectionFactory.CreatePersistent(index++.ToString());
        }

        static DbConnection Created2()
        {
            var connection = new SqlConnection(conn);
            return connection;
        }

        static FakeContextFactory()
        {
            CreateDb();
        }

        public PiforatioContext Create()
        {
            //var context = new PiforatioContext(connection);
            var context = new PiforatioContext(Created2());
            context.Database.CreateIfNotExists();
            context.Database.Log = Write;
            return context;
        }

        static void Write(string value)
        {
            Debug.Write(value, "SQL Output");
        }
    }
}