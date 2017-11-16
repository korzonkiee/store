using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Store.DataAccess;

namespace Store.Migrations
{
    public class CoreDbContextFactory : IDesignTimeDbContextFactory<CoreDbContext>
    {
        public CoreDbContext CreateDbContext(string[] args)
        {
            var connectionString = MigrationsConfig.LoadConnectionString("Store.Api");
            var opts = new DbContextOptionsBuilder<CoreDbContext>()
                .UseSqlServer(connectionString, cfg => {
                    cfg.MigrationsAssembly("Store.Migrations");
                }).Options;

            return new CoreDbContext(opts);
        }
    }
}
