using AutoMapper;
using CMS.Application.ApiModels;
using CMS.Application.Exceptions;
using CMS.Application.Interfaces;
using CMS.Core.Entities;
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
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository customerRepository,IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public Task<bool> AddCustomer(CustomerModel customer)
        {
            try
            {
                //Customer customer = null;
              //   var customerEntity = _mapper.Map<Customer>(customer);
                Customer cust = new Customer
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    MiddleName = customer.MiddleName,
                    UserName = customer.UserName,
                    Password = customer.Password,
                    UserTypeID = customer.UserTypeID
                };

                 return _customerRepository.AddCustomer(cust);
            }
            catch(AutoMapperConfigurationException ex)
            {
                throw new ApiException(ex.Message, 500);
            }
            catch(Exception ex)
            {
                throw new ApiException(ex.Message, 500);
            }
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
