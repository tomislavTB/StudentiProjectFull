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
    public class CountryService : BaseService, ICountryService
    {
        private readonly StudentiProjectContext _context;

        public CountryService(
            StudentiProjectContext context
        ) {
            _context = context;
        }
        
        public async Task<PagedResult<CountryResponse>> GetPageAsync(CountryPaginationRequest request)
        {
            PagedResult<CountryResponse> pagedResult = await _context
                .Countries.AsQueryable()
                .Select(i => new CountryResponse
                {
                    Id = i.Id,
                    Name = i.Name
                  
                })
                .ToPagedResultAsync(request);

            return pagedResult;
        }

        public async Task<CountryResponse> GetByIdAsync(int id)
        {
            return await _context
                .Countries
                .Select(i => new CountryResponse
                {
                    Id = i.Id,
                    Name = i.Name
              
                })
                .FirstAsync();
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            var country = await _context
                .Countries
                .FindAsync(id);
            
            _context.Countries.Remove(country);
            return await _context.SaveChangesAsync();
        }

        public async Task<Country> PostCountry(Country item)
        {
            _context.Countries.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<int> PutCountry(Country item)
        {
            _context.Entry(item).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public async Task<Country> FindAsync(int id)
        {
            return await _context.Countries.FindAsync(id);
        }
    }
}
