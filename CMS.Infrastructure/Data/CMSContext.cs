using CMS.Core.Entities;
using CMS.Infrastructure.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Infrastructure.Data
{
   public class CMSContext : DbContext
    {
        public CMSContext(DbContextOptions<CMSContext> options):base(options)
        {

        }

        public DbSet<UserTypes> UserTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        }

    }
}
