using System;
using core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace migrations
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
