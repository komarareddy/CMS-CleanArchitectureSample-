using CMS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Infrastructure.Data.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> entityTypeBuilder)
        {
            //Configuring one to many relationship
            //Usertypes(admin, BranchHead..) have many customers
            //entityTypeBuilder

            //    .WithMany(c => c.Customers)
            //    .HasForeignKey<int>(s => s.UserTypeID);
            entityTypeBuilder
                .HasOne<UserTypes>(u => u.UserTypes)
                .WithMany(c => c.Customers)
                .HasForeignKey(u => u.UserTypeID);
        }
    }
}
