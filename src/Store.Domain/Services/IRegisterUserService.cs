using System.Threading.Tasks;

namespace Store.Domain.Services
{
    public interface IRegisterUserService
    {
        Task RequestRegistration(string email, string password);
        Task<bool> Register(string email, string password);
    }
}