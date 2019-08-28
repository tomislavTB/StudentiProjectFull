using System.Threading.Tasks;

namespace StudentiProject.Services.Contracts
{
    public interface IAuthService : IAppService
    {
        Task<string> SignInAsync(string email, string password);
        Task<string> RegisterAsync(string email, string password);
    }
}