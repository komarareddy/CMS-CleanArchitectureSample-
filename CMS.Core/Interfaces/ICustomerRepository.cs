using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Interfaces
{
   public interface ICustomerRepository
    {
        Task<bool> AddCustomer(Customer customer);

        Task<ICollection<Customer>> GetCustomers();

        Task<bool> DeleteCustomer();

        Task<bool> UpdateCustomer(int customerID, Customer customer);

        Task<Customer> GetCustomer();
    }
}
