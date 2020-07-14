using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PubQuiz.DB;
using PubQuiz.Model.Users;
using PubQuiz.Services.Contracts;

namespace PubQuiz.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly PubQuizContext Context;

        public UserService(PubQuizContext context)
        {
            Context = context;
        }

        public async Task<AuthUser> getByEmailAsync(string email)
        {
            return await Context.Users
                .Where(u => u.Email == email)
                .Select(u => new AuthUser {
                    Id = u.Id,
                    Email = u.Email
                }).FirstAsync();
        }
    }
}