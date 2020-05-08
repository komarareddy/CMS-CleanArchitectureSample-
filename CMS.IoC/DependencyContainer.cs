using CMS.Application.Helpers;
using CMS.Application.Interfaces;
using CMS.Application.Services;
using CMS.Core.Interfaces;
using CMS.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.IoC
{
   public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection service, IConfiguration configuration)
        {
            //CMS.Application.InterfaceService | CMS.Application.ClassService
            service.AddScoped<ICustomerService, CustomerService>();
            service.AddScoped<IAccountService, AccountService>();

            //CMS.Core.Interface   | CMS.Infrastructure.Repository
            service.AddScoped<ICustomerRepository, CustomerRepository>();
            service.AddScoped<IAccountRepository, AccountRepository>();

            //now we can use Ioptions<jwtSettings> anywhere in our apps
            service.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
        }
    }
}
