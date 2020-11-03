using Microsoft.AspNetCore.Hosting;
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
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<SlijterijSjonnieLoperContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("SlijterijSjonnieLoperContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<SlijterijSjonnieLoperContext>();
            });
        }
    }
}