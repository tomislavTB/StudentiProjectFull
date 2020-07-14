using System.Threading.Tasks;
using PubQuiz.Requests;
using PubQuiz.Responses;
using PubQuiz.DB;
using PubQuiz.Shared.Pagination;
using System.Linq;
using PubQuiz.Shared.Extensions;
using PubQuiz.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using PubQuiz.Services;
using PubQuiz.Models;
using Microsoft.AspNetCore.Mvc;

namespace PubQuiz.Services
{
    public class CityService : BaseService, ICityService
    {
        private readonly PubQuizContext _context;

        public CityService(
            PubQuizContext context
        )
        {
            _context = context;
        }

        public async Task<PagedResult<CityResponse>> GetPageAsync(CityRequest request)
        {
            PagedResult<CityResponse> pagedResult = await _context
                .Cities.AsQueryable()
                .Select(i => new CityResponse
                {
                    Id = i.Id,
                    Name = i.Name,
                    Zip = i.Zip

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
                    Name = i.Name,
                    Zip = i.Zip

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
