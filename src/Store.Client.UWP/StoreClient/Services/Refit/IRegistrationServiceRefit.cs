using Refit;
using StoreClient.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreClient.Services.Refit
{
    public interface IRegistrationServiceRefit
    {
        [Post("/auth/account/register")]
        Task AddUser(User user);
        
    }
}
