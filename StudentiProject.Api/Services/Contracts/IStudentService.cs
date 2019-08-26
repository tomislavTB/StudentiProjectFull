using System.Threading.Tasks;
using StudentiProject.Requests;
using StudentiProject.Responses;
using StudentiProject.Shared.Pagination;

namespace StudentiProject.Services.Contracts
{
    public interface IStudentService
    {
        Task<PagedResult<StudentResponse>> GetPageAsync(StudentPaginationRequest request);
        Task<StudentResponse> GetByIdAsync(long id);

        Task<int> DeleteByIdAsync(long id);
    }
}