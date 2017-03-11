﻿using System.Data.Entity;
using System.Data.Common;

namespace Piforatio.Core2
{
    public class PiforatioContext : DbContext
    {
        public PiforatioContext(DbConnection connection) : base(connection, true) { }
        public DbSet<Quant> Quants { get; set; }
    }
}
