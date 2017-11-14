using Microsoft.EntityFrameworkCore;
using Store.Domain.Models;

namespace Store.DataAccess
{
    public class CoreDbContext : DbContext
    {
        public const string Schema = "core";
        public DbSet<Product> Products => Set<Product>();

        public CoreDbContext(DbContextOptions options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Schema);
            modelBuilder.Entity<Product>(cfg =>
            {
                cfg.HasKey(e => e.Id);
                cfg.Property(e => e.Name).HasMaxLength(200);
            });
        }
    }
}