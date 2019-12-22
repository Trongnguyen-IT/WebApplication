using Microsoft.EntityFrameworkCore;
using T.Core;

namespace T.EntityFrameworkCore
{
    public class TDbContext : DbContext
    {
        public TDbContext(DbContextOptions<TDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
