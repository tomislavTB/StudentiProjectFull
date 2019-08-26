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
    public class TeacherService : BaseService, ITeacherService
    {
        private readonly StudentiProjectContext _context;

        public TeacherService(
            StudentiProjectContext context
        )
        {
            _context = context;
        }

        public async Task<PagedResult<TeacherResponse>> GetPageAsync(TeacherPaginationRequest request)
        {
            PagedResult<TeacherResponse> pagedResult = await _context
                .Teachers.AsQueryable()
                .Select(i => new TeacherResponse
                {
                    Id = i.Id,
                    LastName = i.LastName

                })
                .ToPagedResultAsync(request);

            return pagedResult;
        }

        public async Task<TeacherResponse> GetByIdAsync(long id)
        {
            return await _context
                .Teachers
                .Select(i => new TeacherResponse
                {
                    Id = i.Id,
                    LastName = i.LastName

                })
                .FirstAsync();
        }

        public async Task<int> DeleteByIdAsync(long id)
        {
            var teacher = await _context
                .Teachers
                .FindAsync(id);

            _context.Teachers.Remove(teacher);
            return await _context.SaveChangesAsync();
        }

    }
}