using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Store.Auth;

namespace Store.Migrations
{
    public class AuthDbContextFactory : IDesignTimeDbContextFactory<AuthDbContext>
    {
        public AuthDbContext CreateDbContext(string[] args)
        {
            var connectionString = MigrationsConfig.LoadConnectionString("Store.Auth");
            var opts = new DbContextOptionsBuilder<AuthDbContext>()
                .UseSqlServer(connectionString, cfg => {
                    cfg.MigrationsAssembly("Store.Migrations");
                }).Options;

            return new AuthDbContext(opts);
        }
    }
}