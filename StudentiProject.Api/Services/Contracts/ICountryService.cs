using System.Threading.Tasks;
using StudentiProject.Models;
using StudentiProject.Requests;
using StudentiProject.Responses;
using StudentiProject.Shared.Pagination;

namespace StudentiProject.Services.Contracts
{
    public interface ICountryService
    {
        Task<PagedResult<CountryResponse>> GetPageAsync(CountryPaginationRequest request);
        Task<CountryResponse> GetByIdAsync(int id);

        Task<int> DeleteByIdAsync(int id);
        Task<Country> PostCountry(Country item);
        Task<int> PutCountry(Country item);
        Task<Country> FindAsync(int id);
    }
}