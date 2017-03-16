using System.Data.Entity;
using System.Data.Common;

namespace Piforatio.Core2
{
    public class PiforatioContext : DbContext
    {
        public PiforatioContext(DbConnection connection) : base(connection, true) { }
        public DbSet<Quant> Quants { get; set; }
        public DbSet<Objective> Objectives { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Week> Calendar { get; set; }
    }
}
