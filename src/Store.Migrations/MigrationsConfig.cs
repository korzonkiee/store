using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Store.Migrations
{
    static class MigrationsConfig
    {
        private const string EnvironmentVariableName = "ASPNETCORE_ENVIRONMENT";
        private const string DefaultConnectionStringName = "Database";
 
        public static readonly string EnvironmentName;
 
        static MigrationsConfig()
        {
            EnvironmentName = System.Environment.GetEnvironmentVariable(EnvironmentVariableName);
        }
 
        public static string LoadConnectionString(string app)
        {
            var dir = Path.Combine(Directory.GetCurrentDirectory(), $"../{app}");
 
            var builder = new ConfigurationBuilder()
                .SetBasePath(dir)
                .AddJsonFile($"appsettings.{EnvironmentName}.json", true);
            var configuration = builder.Build();
            return configuration.GetConnectionString(DefaultConnectionStringName);
        }
    }
}
