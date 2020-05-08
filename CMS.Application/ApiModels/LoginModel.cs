using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMS.Application.ApiModels
{
    public class LoginModel
    {
        [Required]
        public String UserName { get; set; }

        [Required]
        public String Password { get; set; }
    }
}
