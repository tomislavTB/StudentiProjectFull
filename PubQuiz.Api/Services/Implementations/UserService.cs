using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PubQuiz.DB;
using PubQuiz.Model.Users;
using PubQuiz.Requests;
using PubQuiz.Responses;
using PubQuiz.Services.Contracts;
using PubQuiz.Shared.Pagination;

namespace PubQuiz.Services.Implementations
{
    public class UserService : BaseService, IUserService
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

        public async Task<AuthUser> GetPageAsync(UserRequest request)
        {
            return await Context.Users
                .Select(u => new AuthUser
                {
                    Id = u.Id,
                    Email = u.Email,
                    FirstName = u.FirstName,
                    LastName = u.LastName
                }).FirstAsync();

        }

        //public async Task<PagedResult<UserResponse>> GetPageAsync(UserRequest request)
        //{
        //    PagedResult<UserResponse> pagedResult = await Context
        //        .Users.AsQueryable()
        //        .Select(i => new AuthUser
        //        {
        //            Id = i.Id,
        //            FirstName = i.FirstName,
        //            LastName = i.LastName,
        //            Email = i.Email

        //       })
        //       .ToPagedResultAsync(request);

        //    return pagedResult;
        //}

        public async Task<int> DeleteByIdAsync(int id)
        {
            var user = await Context
                .Users
                .FindAsync(id);

            Context.Users.Remove(user);
            return await Context.SaveChangesAsync();
        }
    }
}