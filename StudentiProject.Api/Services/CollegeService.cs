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
using StudentiProject.Models;

namespace StudentiProject.Services
{
    public class CollegeService : BaseService, ICollegeService
    {
        private readonly StudentiProjectContext _context;

        public CollegeService(
            StudentiProjectContext context
        )
        {
            _context = context;
        }

        public async Task<PagedResult<CollegeResponse>> GetPageAsync(CollegePaginationRequest request)
        {
            PagedResult<CollegeResponse> pagedResult = await _context
                .Colleges.AsQueryable()
                .Select(i => new CollegeResponse
                {
                    Id = i.Id,
                    Name = i.Name

                })
                .ToPagedResultAsync(request);

            return pagedResult;
        }

        public async Task<CollegeResponse> GetByIdAsync(int id)
        {
            return await _context
                .Colleges
                .Select(i => new CollegeResponse
                {
                    Id = i.Id,
                    Name = i.Name

                })
                .FirstAsync();
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            var college = await _context
                .Colleges
                .FindAsync(id);

            _context.Colleges.Remove(college);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> PutCollege(College item)
        {
            _context.Entry(item).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    

        public async Task<College> FindAsync(int id)
        {
            return await _context.Colleges.FindAsync(id);
        }

        public async Task<College> PostCollege(College item)
        {
        _context.Colleges.Add(item);
        await _context.SaveChangesAsync();
        return item;
        }

    }
}


