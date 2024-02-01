using Microsoft.EntityFrameworkCore;

namespace taskFelipe.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() { }

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<Task> Tasks { get; set; }

    }
}
