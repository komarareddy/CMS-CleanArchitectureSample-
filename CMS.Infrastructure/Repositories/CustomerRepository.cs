using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CMSContext _context;
        public CustomerRepository(CMSContext context)
        {
            _context = context;
        }
        public async Task<bool> AddCustomer(Customer customer)
        {
            bool isInserted = false;
            try
            {
                await _context.Customers.AddAsync(customer);
                await _context.SaveChangesAsync();
                isInserted = true;
            }
            catch(Exception ex)
            {
                throw;
            }
            return isInserted;
        }

        public async Task<bool> DeleteCustomer()
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> GetCustomer()
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Customer>> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateCustomer(int customerID, Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
