using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SendGrid;
using SendGrid.Helpers.Mail;
using SlijterijSjonnieLoper.Services;

namespace SlijterijSjonnieLoper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Execute().Wait();
            CreateHostBuilder(args).Build().Run();

        }
        //static async Task Execute()
        //{
        //    var apiKey = "ZEGIKNIET";
        //    var client = new SendGridClient(apiKey);
        //    var from = new EmailAddress("example@example.nl", "Example User");
        //    var subject = "Sending with SendGrid is Fun";
        //    var to = new EmailAddress("example@examplea", "Example User");
        //    var plainTextContent = "and easy to do anywhere, even with C#";
        //    var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
        //    var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
        //    var response = await client.SendEmailAsync(msg);
        //}

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
