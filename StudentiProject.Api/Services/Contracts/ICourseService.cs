using System.Threading.Tasks;
using StudentiProject.Requests;
using StudentiProject.Responses;
using StudentiProject.Shared.Pagination;

namespace StudentiProject.Services.Contracts
{
    public interface ICourseService
    {
        Task<PagedResult<CourseResponse>> GetPageAsync(CoursePaginationRequest request);
        Task<CourseResponse> GetByIdAsync(long id);

        Task<int> DeleteByIdAsync(long id);
    }
}