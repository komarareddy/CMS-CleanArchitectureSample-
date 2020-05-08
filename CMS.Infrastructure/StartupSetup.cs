using CMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Infrastructure
{
   public static class StartupSetup
    {
        public static void AddDbContext1(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CMSContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
