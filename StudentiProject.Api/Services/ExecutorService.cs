using System.Threading.Tasks;
using StudentiProject.Requests;
using StudentiProject.Responses;
using StudentiProject.DB;
using StudentiProject.Shared.Pagination;
using System.Linq;
using StudentiProject.Shared.Extensions;
using StudentiProject.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using StudentiProject.Services;

namespace StudentiProject.Services
{
    public class ExecutorService : BaseService, IExecutorService
    {
        private readonly StudentiProjectContext _context;

        public ExecutorService(
            StudentiProjectContext context
        )
        {
            _context = context;
        }

        public async Task<PagedResult<ExecutorResponse>> GetPageAsync(ExecutorPaginationRequest request)
        {
            PagedResult<ExecutorResponse> pagedResult = await _context
                .Executors.AsQueryable()
                .Select(i => new ExecutorResponse
                {
                    Id = i.Id,
                    Description = i.Description


                })
                .ToPagedResultAsync(request);

            return pagedResult;
        }

        public async Task<ExecutorResponse> GetByIdAsync(long id)
        {
            return await _context
                .Executors
                .Select(i => new ExecutorResponse
                {
                    Id = i.Id,
                    Description = i.Description

                })
                .FirstAsync();
        }

        public async Task<int> DeleteByIdAsync(long id)
        {
            var executor = await _context
                .Executors
                .FindAsync(id);

            _context.Executors.Remove(executor);
            return await _context.SaveChangesAsync();
        }

    }
}