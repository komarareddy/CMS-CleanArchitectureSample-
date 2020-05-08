using CMS.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.API
{
    public static class SeedData
    {
       
        public static void Initialize(IServiceProvider provider)
        {

        }

        public static void PopulateTestData(CMSContext dbContext)
        {
            //foreach (var item in dbContext.UserTypes)
            //{
            //    dbContext.Remove(item);
            //}
            //dbContext.SaveChanges();

            //dbContext.UserTypes.Add();
        }
    }
}
