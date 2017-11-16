using Microsoft.EntityFrameworkCore;
using Store.Domain.Models;

namespace Store.DataAccess
{
    public class CoreDbContext : DbContext
    {
        public const string Schema = "core";

        public DbSet<Category> Categories => Set<Category>();
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

            modelBuilder.Entity<Category>(cfg =>
            {
                cfg.HasKey(e => e.Id);
                cfg.Property(e => e.Name).HasMaxLength(1000);
            });

            modelBuilder.Entity<CategoryProduct>()
                .HasKey(cp => new { cp.CategoryId, cp.ProductId });

            modelBuilder.Entity<CategoryProduct>()
                .HasOne(cp => cp.Category)
                .WithMany(c => c.CategoryProducts)
                .HasForeignKey(cp => cp.CategoryId);
        }
    }
}