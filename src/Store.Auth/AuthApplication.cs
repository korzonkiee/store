using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Auth.IdentityServer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;

namespace Store.Auth
{
    public class AuthApplication
    {
        private readonly IConfiguration configuration;
        private readonly IHostingEnvironment hostEnv;

        public AuthApplication(IConfiguration configuration, IHostingEnvironment hostEnv)
        {
            this.configuration = configuration;
            this.hostEnv = hostEnv;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureIdentityServer(services);

            services.AddDbContext<AuthDbContext>(opts =>
            {
                opts.UseSqlServer(configuration.GetConnectionString("Database"), cfg =>
                {
                    cfg.MigrationsAssembly("Store.Migrations");
                });
            });

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AuthDbContext>()
                .AddDefaultTokenProviders();
        }

        public void Configure(IApplicationBuilder app)
        {
            if (hostEnv.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentityServer();
        }

        private void ConfigureIdentityServer(IServiceCollection services)
        {
            services.AddIdentityServer()
                .AddInMemoryIdentityResources(IdentityServerConfig.GetIdentityResources())
                .AddInMemoryClients(IdentityServerConfig.GetClients());
        }
    }
}
