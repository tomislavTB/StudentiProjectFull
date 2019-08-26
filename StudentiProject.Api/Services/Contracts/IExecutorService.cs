using System.Threading.Tasks;
using StudentiProject.Requests;
using StudentiProject.Responses;
using StudentiProject.Shared.Pagination;

namespace StudentiProject.Services.Contracts
{
    public interface IExecutorService
    {
        Task<PagedResult<ExecutorResponse>> GetPageAsync(ExecutorPaginationRequest request);
        Task<ExecutorResponse> GetByIdAsync(long id);

        Task<int> DeleteByIdAsync(long id);
    }
}