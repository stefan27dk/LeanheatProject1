using System;
using LeanheatProject1.Server.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(LeanheatProject1.Server.Areas.Identity.IdentityHostingStartup))]
namespace LeanheatProject1.Server.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<LeanheatProject1ServerLogInContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("LeanheatProject1ServerContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<LeanheatProject1ServerLogInContext>();
            });
        }
    }
}