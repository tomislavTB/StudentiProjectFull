using System.Threading.Tasks;
using StudentiProject.Requests;
using StudentiProject.Responses;
using StudentiProject.Shared.Pagination;

namespace StudentiProject.Services.Contracts
{
    public interface IDivisionService
    {
        Task<PagedResult<DivisionResponse>> GetPageAsync(DivisionPaginationRequest request);
        Task<DivisionResponse> GetByIdAsync(long id);

        Task<int> DeleteByIdAsync(long id);
    }
}