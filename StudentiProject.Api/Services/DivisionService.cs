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
    public class DivisionService : BaseService, IDivisionService
    {
        private readonly StudentiProjectContext _context;

        public DivisionService(
            StudentiProjectContext context
        )
        {
            _context = context;
        }

        public async Task<PagedResult<DivisionResponse>> GetPageAsync(DivisionPaginationRequest request)
        {
            PagedResult<DivisionResponse> pagedResult = await _context
                .Divisions.AsQueryable()
                .Select(i => new DivisionResponse
                {
                    Id = i.Id,
                    Name = i.Name

                })
                .ToPagedResultAsync(request);

            return pagedResult;
        }

        public async Task<DivisionResponse> GetByIdAsync(long id)
        {
            return await _context
                .Divisions
                .Select(i => new DivisionResponse
                {
                    Id = i.Id,
                    Name = i.Name

                })
                .FirstAsync();
        }

        public async Task<int> DeleteByIdAsync(long id)
        {
            var division = await _context
                .Divisions
                .FindAsync(id);

            _context.Divisions.Remove(division);
            return await _context.SaveChangesAsync();
        }

    }
}