using Microsoft.EntityFrameworkCore;

namespace P1API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<P1> P1s { get; set; }
        



    }
}
