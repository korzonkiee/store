using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IdentityServer4;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Store.Api.Services;
using Store.Auth;
using Store.DataAccess;
using Store.DataAccess.Repository;
using Store.Domain.Bus;
using Store.Domain.CommandHandlers;
using Store.Domain.Commands;
using Store.Domain.EventHandlers;
using Store.Domain.Events;
using Store.Domain.Repository;
using Store.Infrastructure.Bus;
using Swashbuckle.AspNetCore.Swagger;

namespace Store.Api
{
    public class Startup
    {
        private readonly AuthApplication authApplication;
        public Startup(IHostingEnvironment hostingEnvironment)
        {
            Environment = hostingEnvironment;

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.{hostingEnvironment.EnvironmentName}.json", true, true);

            Configuration = builder.Build();

            authApplication = new AuthApplication(Configuration, Environment);
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CoreDbContext>(opts =>
            {
                var connectionString = Configuration.GetConnectionString("Database");
                opts.UseSqlServer(Configuration.GetConnectionString("Database"), cfg =>
                {
                    cfg.MigrationsAssembly("Store.Migrations");
                });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Store API", Version = "v1" });
            });

            // Repositories
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<IProductsRepository, ProductsRepository>();

            // EventHandlers
            services.AddScoped<INotificationHandler<DomainEvent>, DomainEventHandler>();

            // CommandHandlers
            services.AddScoped<INotificationHandler<AddCategoryCommand>, AddCategoryCommandHandler>();
            services.AddScoped<INotificationHandler<AddProductCommand>, AddProductCommandHandler>();
            services.AddScoped<IBus, InMemoryBus>();

            // Services
            services.AddTransient<ICategoriesService, CategoriesService>();
            services.AddTransient<IProductsService, ProductsService>();

            //Auth
            services.AddAuthentication(
                options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
            .AddJwtBearer(cfg =>
            {
                cfg.Authority = Configuration["Identity:Address"];
                cfg.TokenValidationParameters.ValidateAudience = false;
                cfg.TokenValidationParameters.ValidateIssuer = false;

                cfg.RequireHttpsMetadata = false;

                cfg.TokenValidationParameters.RoleClaimType = "role";
            });

            // Plugins
            services.AddAutoMapper();
            services.AddMediatR(typeof(Startup));

            services.AddMvc();

            authApplication.ConfigureServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            authApplication.Configure(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Store API V1");
            });

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
