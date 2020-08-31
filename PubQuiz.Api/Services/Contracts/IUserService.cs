using System.Threading.Tasks;
using PubQuiz.Model.Users;
using PubQuiz.Requests;
using PubQuiz.Responses;
using PubQuiz.Shared.Pagination;

namespace PubQuiz.Services.Contracts
{
    public interface IUserService
    {
        Task<AuthUser> getByEmailAsync(string email);
        Task<AuthUser> GetPageAsync(UserRequest request);
        Task<int> DeleteByIdAsync(int id);
    }
} 