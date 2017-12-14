using Refit;
using StoreClient.DTOs;
using StoreClient.Services.Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreClient.Services
{

    public interface IRegistrationService
    {
        Task AddUser(User user);

    }


    public class RegistrationService : IRegistrationService
    {

        public async Task AddUser(User user)
        {
            await RestService.For<IRegistrationServiceRefit>("http://localhost:5005").AddUser(user);
        }
    }
}

