﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SlijterijSjonnieLoper.Data;

[assembly: HostingStartup(typeof(SlijterijSjonnieLoper.Areas.Identity.IdentityHostingStartup))]

namespace SlijterijSjonnieLoper.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        //scaffold file identity
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<SjonnieLoperDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("SlijterijSjonnieLoperContextConnection")));

                services.AddDefaultIdentity<SlijterijSjonnieLoper.Core.ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<SjonnieLoperDbContext>();
            });
        }
    }
}