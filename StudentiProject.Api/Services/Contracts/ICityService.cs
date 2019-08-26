using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentiProject.Models;
using StudentiProject.Requests;
using StudentiProject.Responses;
using StudentiProject.Shared.Pagination;

namespace StudentiProject.Services.Contracts
{
    public interface ICityService
    {
        Task<PagedResult<CityResponse>> GetPageAsync(CityPaginationRequest request);
        Task<CityResponse> GetByIdAsync(int id);

        Task<int> DeleteByIdAsync(int id);

        Task<City> FindAsync(int id);
        Task<int> PutCity(City item);
        Task<City> PostCity(City item);
    }
}