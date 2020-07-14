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

namespace PubQuiz.Services
{
    public class CountryService : BaseService, ICountryService
    {
        private readonly PubQuizContext _context;

        public CountryService(
            PubQuizContext context
        ) {
            _context = context;
        }
        
        public async Task<PagedResult<CountryResponse>> GetPageAsync(CountryRequest request)
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
