using CMS.Application.ApiModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Application.Interfaces
{
    public interface IAccountService
    {
        UserLoginResponse Authenticate(string userName, string password);
    }
}
