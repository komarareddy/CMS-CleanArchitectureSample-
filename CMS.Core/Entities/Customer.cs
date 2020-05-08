using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CMS.Core.Entities
{
   public class Customer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

       //Navigatio Properties
       public int? UserTypeID { get; set; }
        public  UserTypes UserTypes { get; set; }
    }
}
