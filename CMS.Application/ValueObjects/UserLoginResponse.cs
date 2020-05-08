using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Application.ApiModels
{
   public class UserLoginResponse
    {
        public string UserName { get; set; }

        public string Token { get; set; }

        public string UserType { get; set; }
    }
}
