using ASP_Net_base.Modules.Accounts;
using Microsoft.EntityFrameworkCore;

namespace ASP_Net_base.DAL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public void RecreateDatabase()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<AccountEntity> Accounts => Set<AccountEntity>();
    }
}
