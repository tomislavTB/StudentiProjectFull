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
    public class GradeService : BaseService, IGradeService
    {
        private readonly StudentiProjectContext _context;

        public GradeService(
            StudentiProjectContext context
        )
        {
            _context = context;
        }

        public async Task<PagedResult<GradeResponse>> GetPageAsync(GradePaginationRequest request)
        {
            PagedResult<GradeResponse> pagedResult = await _context
                .Grades.AsQueryable()
                .Select(i => new GradeResponse
                {
                    Id = i.Id,
                    Evaluation = i.Evaluation

                })
                .ToPagedResultAsync(request);

            return pagedResult;
        }

        public async Task<GradeResponse> GetByIdAsync(long id)
        {
            return await _context
                .Grades
                .Select(i => new GradeResponse
                {
                    Id = i.Id,
                    Evaluation = i.Evaluation

                })
                .FirstAsync();
        }

        public async Task<int> DeleteByIdAsync(long id)
        {
            var grade = await _context
                .Grades
                .FindAsync(id);

            _context.Grades.Remove(grade);
            return await _context.SaveChangesAsync();
        }

    }
}