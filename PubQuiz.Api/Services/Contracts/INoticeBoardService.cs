using System.Threading.Tasks;
using PubQuiz.Models;
using PubQuiz.Requests;
using PubQuiz.Responses;
using PubQuiz.Shared.Pagination;

namespace PubQuiz.Services.Contracts
{
    public interface INoticeBoardService
    {
        Task<PagedResult<NoticeBoardResponse>> GetPageAsync(NoticeBoardRequest request);
        Task<NoticeBoardResponse> GetByIdAsync(int id);

        Task<int> DeleteByIdAsync(int id);
        Task<int> PutNoticeBoard(NoticeBoard item);
        Task<NoticeBoard> FindAsync(int id);
        Task<NoticeBoard> PostNoticeBoard(NoticeBoard item);
    }
}