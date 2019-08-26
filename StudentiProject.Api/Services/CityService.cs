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
using Microsoft.AspNetCore.Mvc;

namespace StudentiProject.Services
{
    public class CityService : BaseService, ICityService
    {
        private readonly StudentiProjectContext _context;

        public CityService(
            StudentiProjectContext context
        )
        {
            _context = context;
        }

        public async Task<PagedResult<CityResponse>> GetPageAsync(CityPaginationRequest request)
        {
            PagedResult<CityResponse> pagedResult = await _context
                .Cities.AsQueryable()
                .Select(i => new CityResponse
                {
                    Id = i.Id,
                    Name = i.Name

                })
                .ToPagedResultAsync(request);

            return pagedResult;
        }

        public async Task<CityResponse> GetByIdAsync(int id)
        {
            return await _context
                .Cities
                .Select(i => new CityResponse
                {
                    Id = i.Id,
                    Name = i.Name

                })
                .FirstAsync();
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            var city = await _context
                .Cities
                .FindAsync(id);

            _context.Cities.Remove(city);
            return await _context.SaveChangesAsync();
        }

        public async Task<City> FindAsync(int id)
        {
            return await _context.Cities.FindAsync(id);
        }

        public async Task<int> PutCity(City item)
        {
            _context.Entry(item).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }


        public async Task<City> PostCity(City item)
        {
            _context.Cities.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}
