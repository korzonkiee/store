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
            var connectionString = MigrationsConfig.LoadConnectionString("api");
            var opts = new DbContextOptionsBuilder<CoreDbContext>()
                .UseSqlServer(connectionString, cfg => {
                    cfg.MigrationsAssembly("migrations");
                }).Options;

            return new CoreDbContext(opts);
        }
    }
}
