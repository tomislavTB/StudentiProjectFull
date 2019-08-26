using System.Threading.Tasks;
using StudentiProject.Requests;
using StudentiProject.Responses;
using StudentiProject.Shared.Pagination;

namespace StudentiProject.Services.Contracts
{
    public interface ITeacherService
    {
        Task<PagedResult<TeacherResponse>> GetPageAsync(TeacherPaginationRequest request);
        Task<TeacherResponse> GetByIdAsync(long id);

        Task<int> DeleteByIdAsync(long id);
    }
}