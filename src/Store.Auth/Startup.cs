using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Validation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Store.Auth.Facebook;
using Store.Auth.IdentityServer;
using Store.Auth.Services;
using Store.Domain.Bus;
using Store.Domain.CommandHandlers;
using Store.Domain.Commands;
using Store.Domain.EventHandlers;
using Store.Domain.Events;
using Store.Domain.Services;
using Store.Infrastructure.Bus;

namespace Store.Auth
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AuthDbContext>(opts =>
            {
                opts.UseSqlServer(Configuration.GetConnectionString("Database"), cfg =>
                {
                    cfg.MigrationsAssembly("Store.Migrations");
                });
            });

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AuthDbContext>()
                .AddDefaultTokenProviders();

            services.AddIdentityServer()
                .AddInMemoryIdentityResources(IdentityServerConfig.GetIdentityResources())
                .AddInMemoryApiResources(IdentityServerConfig.GetApiResources())
                .AddInMemoryClients(IdentityServerConfig.GetClients())
                .AddDeveloperSigningCredential()
                .AddAspNetIdentity<IdentityUser>();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;                
            });

            services.AddMediatR(typeof(Startup));

            services.AddMvc();

            //Facebook
            services.AddScoped<FacebookClient, FacebookClient>();

            //Services
            services.AddTransient<IRegisterUserService, RegisterUserService>();

            //Event handlers
            services.AddScoped<INotificationHandler<DomainEvent>, DomainEventHandler>();

            // CommandHandlers
            services.AddScoped<IAsyncNotificationHandler<RegisterUserCommand>, RegisterUserCommandHandler>();
            services.AddScoped<IBus, InMemoryBus>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentityServer();

            app.UseMvc();
        }
    }
}
