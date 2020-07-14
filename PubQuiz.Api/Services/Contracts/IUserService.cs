using System.Threading.Tasks;
using PubQuiz.Model.Users;

namespace PubQuiz.Services.Contracts
{
    public interface IUserService
    {
        Task<AuthUser> getByEmailAsync(string email);
    }
}