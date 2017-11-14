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
using Store.Domain.CommandHandlers;
using Store.Domain.Commands;
using Store.Domain.Repository;
using Store.Infrastructure.Bus;

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
                opts.UseSqlServer(Configuration.GetConnectionString("Database"), cfg =>
                {
                    cfg.MigrationsAssembly("migrations");
                });
            });

            // Repositories
            services.AddScoped<IProductsRepository, ProductsRepository>();

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

            app.UseMvc();
        }
    }
}
