using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SlijterijSjonnieLoper.Core;
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

                services.AddAuthorization(options =>
               options.AddPolicy("IsAdmin", policy => policy.RequireClaim("IsAdmin")));
                services.AddRazorPages();
                //services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                //    .AddEntityFrameworkStores<SjonnieLoperDbContext>();

                services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<SjonnieLoperDbContext>()
                    .AddDefaultTokenProviders();

                services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>,
                    AdditionalUserClaimsPrincipalFactory>();

                //services.AddAuthorization(options =>
                //{
                //    options.AddPolicy("IsAdmin", policy =>
                //           policy.RequireRole("IsAdmin"));
                //});

            });
        }
    }
}