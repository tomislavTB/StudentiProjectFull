using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PubQuiz.Models;
using PubQuiz.Requests;
using PubQuiz.Responses;
using PubQuiz.Shared.Pagination;

namespace PubQuiz.Services.Contracts
{
    public interface ICityService
    {
        Task<PagedResult<CityResponse>> GetPageAsync(CityRequest request);
        Task<CityResponse> GetByIdAsync(int id);

        Task<int> DeleteByIdAsync(int id);

        Task<City> FindAsync(int id);
        Task<int> PutCity(City item);
        Task<City> PostCity(City item);
    }
}