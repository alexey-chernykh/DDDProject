using Entities;
using Microsoft.EntityFrameworkCore;

namespace Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Player>? Players { get; set; }

        public AppDbContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}