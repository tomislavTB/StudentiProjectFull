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
    public class StudentService : BaseService, IStudentService
    {
        private readonly StudentiProjectContext _context;

        public StudentService(
            StudentiProjectContext context
        )
        {
            _context = context;
        }

        public async Task<PagedResult<StudentResponse>> GetPageAsync(StudentPaginationRequest request)
        {
            PagedResult<StudentResponse> pagedResult = await _context
                .Students.AsQueryable()
                .Select(i => new StudentResponse
                {
                    Id = i.Id,
                    LastName = i.LastName

                })
                .ToPagedResultAsync(request);

            return pagedResult;
        }

        public async Task<StudentResponse> GetByIdAsync(long id)
        {
            return await _context
                .Students
                .Select(i => new StudentResponse
                {
                    Id = i.Id,
                    LastName = i.LastName

                })
                .FirstAsync();
        }

        public async Task<int> DeleteByIdAsync(long id)
        {
            var student = await _context
                .Students
                .FindAsync(id);

            _context.Students.Remove(student);
            return await _context.SaveChangesAsync();
        }

    }
}