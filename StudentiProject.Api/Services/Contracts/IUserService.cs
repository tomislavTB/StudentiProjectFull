using System.Threading.Tasks;
using StudentiProject.Model.Users;

namespace StudentiProject.Services.Contracts
{
    public interface IUserService
    {
        Task<AuthUser> getByEmailAsync(string email);
    }
}