
using Microsoft.EntityFrameworkCore;
using September122006.Models.Domain;

namespace September122006.Models.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Product> Products => Set<Product>();

        public object? Product { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    } 
}
