using System.Threading.Tasks;
using PubQuiz.Models;
using PubQuiz.Requests;
using PubQuiz.Responses;
using PubQuiz.Shared.Pagination;

namespace PubQuiz.Services.Contracts
{
    public interface ICountryService
    {
        Task<PagedResult<CountryResponse>> GetPageAsync(CountryRequest request);
        Task<CountryResponse> GetByIdAsync(int id);

        Task<int> DeleteByIdAsync(int id);
        Task<Country> PostCountry(Country item);
        Task<int> PutCountry(Country item);
        Task<Country> FindAsync(int id);
    }
}