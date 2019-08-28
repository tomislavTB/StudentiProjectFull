using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentiProject.DB;
using StudentiProject.Model.Users;
using StudentiProject.Services.Contracts;

namespace StudentiProject.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly StudentiProjectContext Context;

        public UserService(StudentiProjectContext context)
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