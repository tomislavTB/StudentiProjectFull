using System.Threading.Tasks;
using StudentiProject.Models;
using StudentiProject.Requests;
using StudentiProject.Responses;
using StudentiProject.Shared.Pagination;

namespace StudentiProject.Services.Contracts
{
    public interface ICollegeService
    {
        Task<PagedResult<CollegeResponse>> GetPageAsync(CollegePaginationRequest request);
        Task<CollegeResponse> GetByIdAsync(int id);

        Task<int> DeleteByIdAsync(int id);
        Task<int> PutCollege(College item);
        Task<College> FindAsync(int id);
        Task<College> PostCollege(College item);
    }
}