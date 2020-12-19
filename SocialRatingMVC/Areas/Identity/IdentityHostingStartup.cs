using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialRatingMVC.Data;
using SocialRatingMVC.Models;

[assembly: HostingStartup(typeof(SocialRatingMVC.Areas.Identity.IdentityHostingStartup))]
namespace SocialRatingMVC.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<SocialDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ApplicationDbContextConnection")));

                //services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                //    .AddEntityFrameworkStores<SocialDbContext>();
            });
        }
    }
}