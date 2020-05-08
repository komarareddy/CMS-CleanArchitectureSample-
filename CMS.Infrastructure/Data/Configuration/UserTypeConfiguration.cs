using CMS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Infrastructure.Data.Configuration
{
   public class UserTypeConfiguration : IEntityTypeConfiguration<UserTypes>
    {
        public void Configure(EntityTypeBuilder<UserTypes> entityTypeBuilder)
        {

            entityTypeBuilder.HasData(
                new UserTypes 
                {
                    ID = 1,
                    UserType = "Admin" 
                },
               new UserTypes
               {
                   ID = 2,
                   UserType ="BrachHead"
               });
        }
    }
}
