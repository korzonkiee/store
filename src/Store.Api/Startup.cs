using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Store.Api.Services;
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
        public Startup(IHostingEnvironment hostingEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.{hostingEnvironment.EnvironmentName}.json", true, true);

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

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
            services.AddScoped<IProductsRepository, ProductsRepository>();

            // EventHandlers
            services.AddScoped<INotificationHandler<DomainEvent>, DomainEventHandler>();

            // CommandHandlers
            services.AddScoped<INotificationHandler<AddProductCommand>, AddProductCommandHandler>();
            services.AddScoped<IBus, InMemoryBus>();

            // Services
            services.AddTransient<IProductsService, ProductsService>();

            // Plugins
            services.AddAutoMapper();
            services.AddMediatR(typeof(Startup));

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
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

            app.UseMvc();
        }
    }
}
