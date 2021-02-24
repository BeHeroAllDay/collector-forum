using System;
using collector_forum.Areas.Identity.Data;
using collector_forum.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(collector_forum.Areas.Identity.IdentityHostingStartup))]
namespace collector_forum.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                //services.AddDbContext<AuthDBContext>(options =>
                //    options.UseSqlServer(
                //        context.Configuration.GetConnectionString("AuthDBContextConnection")));


                //services.AddDefaultIdentity<ApplicationUser>(options =>
                //{
                //    options.SignIn.RequireConfirmedAccount = false;
                //    options.Password.RequireLowercase = false;
                //    options.Password.RequireUppercase = false;
                //    options.Password.RequireNonAlphanumeric = false;
                //})

                 //services.AddIdentity<ApplicationUser, IdentityRole>(config =>
                 //{
                 //    config.SignIn.RequireConfirmedEmail = true;
                 //    config.Password.RequireLowercase = false;
                 //    config.Password.RequireUppercase = false;
                 //    config.Password.RequireNonAlphanumeric = false;
                 //})

                 //   .AddEntityFrameworkStores<AuthDBContext>();
            });

        }
    }
}