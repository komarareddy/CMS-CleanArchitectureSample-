using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly CMSContext _context;
        public AccountRepository(CMSContext cMSContext)
        {
            _context = cMSContext;
        }
        public Customer Authenticate(string userName, string password)
        {
            try
            {
                var user = _context.Customers.Include(s=>s.UserTypes).Where(x => x.UserName == userName && x.Password == password).FirstOrDefault();
                if(user != null)
                {
                    return user;
                }
                else
                {
                    return null;
                }
                   
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
