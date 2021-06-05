using FastighetsProjectApi_CCRA.Contracs;
using FastighetsProjectApi_CCRA.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastighetsProjectApi_CCRA.Extension
{

    public static class ServiceExtensions //Needs to be static
    {
        public static void ConfigureCors(this IServiceCollection services) =>
          services.AddCors(options =>
          {
              options.AddPolicy("CorsPolicy", builder =>
              builder.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
          });

        public static void ConfigureIISIntergration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>
            {

            });


        //public static void ConfigureLoggerService(this IServiceCollection services) => //X
        //    services.AddScoped<ILoggerManager, LoggerManager>();

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<DbContext>(opts => //RepistoryContext?
            opts.UseSqlServer(configuration.GetConnectionString("DbContext"), b =>
            b.MigrationsAssembly("FastighetsProjectApi-CCRA")));


        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();
    }
}


