using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CMS.API
{
    /// <summary>
    /// Entry point to application
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method of the application, sets the default setting
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            try
            {
                using (var scope=host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    try
                    {
                        var context = services.GetRequiredService<CMSContext>();

                        //Database migration
                        context.Database.Migrate();

                        //seed data
                        //SeedData.Initialize(services);
                    }
                    catch(Exception ex)
                    {
                        throw;
                    }
                }
            }
            catch(Exception ex)
            {

            }

            host.Run();


        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
