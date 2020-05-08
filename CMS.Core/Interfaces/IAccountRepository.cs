using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Core.Interfaces
{
   public interface IAccountRepository
    {
        Customer Authenticate(string userName, string password);
    }
}
