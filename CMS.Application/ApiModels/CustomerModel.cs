using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Application.ApiModels
{
   public class CustomerModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
