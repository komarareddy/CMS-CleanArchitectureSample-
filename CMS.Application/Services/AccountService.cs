using CMS.Application.ApiModels;
using CMS.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Application.Services
{
    public class AccountService : IAccountService
    {
        public UserLoginResponse Authenticate(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
