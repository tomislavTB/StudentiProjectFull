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
    public class CourseService : BaseService, ICourseService
    {
        private readonly StudentiProjectContext _context;

        public CourseService(
            StudentiProjectContext context
        )
        {
            _context = context;
        }

        public async Task<PagedResult<CourseResponse>> GetPageAsync(CoursePaginationRequest request)
        {
            PagedResult<CourseResponse> pagedResult = await _context
                .Courses.AsQueryable()
                .Select(i => new CourseResponse
                {
                    Id = i.Id,
                    Name = i.Name

                })
                .ToPagedResultAsync(request);

            return pagedResult;
        }

        public async Task<CourseResponse> GetByIdAsync(long id)
        {
            return await _context
                .Courses
                .Select(i => new CourseResponse
                {
                    Id = i.Id,
                    Name = i.Name

                })
                .FirstAsync();
        }

        public async Task<int> DeleteByIdAsync(long id)
        {
            var course = await _context
                .Courses
                .FindAsync(id);

            _context.Courses.Remove(course);
            return await _context.SaveChangesAsync();
        }

    }
}