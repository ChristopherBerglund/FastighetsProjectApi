using System;
using FastighetsProjectApi_CCRA.Areas.Identity.Data;
using FastighetsProjectApi_CCRA.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(FastighetsProjectApi_CCRA.Areas.Identity.IdentityHostingStartup))]
namespace FastighetsProjectApi_CCRA.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<FastighetsProjectApi_CCRAContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("FastighetsProjectApi_CCRAContextConnection")));

                services.AddDefaultIdentity<FastighetsProjectApi_CCRAUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<FastighetsProjectApi_CCRAContext>();
            });
        }
    }
}