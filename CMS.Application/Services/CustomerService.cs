using CMS.Application.ApiModels;
using CMS.Application.Interfaces;
using CMS.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public Task<bool> AddCustomer(CustomerModel customer)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCustomer()
        {
            throw new NotImplementedException();
        }

        public Task<CustomerModel> GetCustomer()
        {
            throw new NotImplementedException();
        }

        public ICollection<CustomerModel> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCustomer(int customerID, CustomerModel customer)
        {
            throw new NotImplementedException();
        }
    }
}
