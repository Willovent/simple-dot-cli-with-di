using Microsoft.EntityFrameworkCore;

namespace SimpleCLI
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}