using System.Threading.Tasks;
using StudentiProject.Requests;
using StudentiProject.Responses;
using StudentiProject.Shared.Pagination;

namespace StudentiProject.Services.Contracts
{
    public interface IGradeService
    {
        Task<PagedResult<GradeResponse>> GetPageAsync(GradePaginationRequest request);
        Task<GradeResponse> GetByIdAsync(long id);

        Task<int> DeleteByIdAsync(long id);
    }
}