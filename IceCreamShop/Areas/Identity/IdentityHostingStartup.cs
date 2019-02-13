using System;
using IceCreamShop.Areas.Identity.Data;
using IceCreamShop.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(IceCreamShop.Areas.Identity.IdentityHostingStartup))]
namespace IceCreamShop.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<IceCreamShopContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("IceCreamShopContextConnection")));

                services.AddDefaultIdentity<IceCreamShopUser>()
                    .AddEntityFrameworkStores<IceCreamShopContext>();
            });
        }
    }
}