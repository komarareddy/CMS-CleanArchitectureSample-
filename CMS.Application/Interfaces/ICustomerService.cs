using CMS.Application.ApiModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Interfaces
{
  public  interface ICustomerService
    {
        Task<bool> AddCustomer(CustomerModel customer);

        ICollection<CustomerModel> GetCustomers();

        Task<bool> DeleteCustomer();

        Task<bool> UpdateCustomer(int customerID, CustomerModel customer);

        Task<CustomerModel> GetCustomer();
    }
}
