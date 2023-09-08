using Microsoft.EntityFrameworkCore;

namespace ASP_Net_base.DAL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public void InitDb()
        {
            Database.EnsureCreated();
            Database.EnsureDeleted();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
