using System.ComponentModel.DataAnnotations;

namespace CMS.Application.ApiModels
{
    public class CustomerModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int UserTypeID { get; set; }
    }
}
