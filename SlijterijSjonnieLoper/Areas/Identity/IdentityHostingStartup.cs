using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SlijterijSjonnieLoper.Data;
using SlijterijSjonnieLoper.Core;
using SlijterijSjonnieLoper;
using Microsoft.AspNetCore.Authorization;

[assembly: HostingStartup(typeof(SlijterijSjonnieLoper.Areas.Identity.IdentityHostingStartup))]

namespace SlijterijSjonnieLoper.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<SjonnieLoperDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("SlijterijSjonnieLoperContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<SjonnieLoperDbContext>();

                services.AddAuthorization(options =>
                {
                    options.AddPolicy("IsAdmin", policy => policy.RequireClaim("role","admin"));
                    options.AddPolicy("NoAdmin", policy => policy.RequireClaim("role", "user"));
                });


                services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, AdditionalUserClaimsPrincipalFactory>();

            });
        }
    }
}