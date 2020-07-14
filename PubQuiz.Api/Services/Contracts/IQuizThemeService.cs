using System.Threading.Tasks;
using PubQuiz.Models;
using PubQuiz.Requests;
using PubQuiz.Responses;
using PubQuiz.Shared.Pagination;

namespace PubQuiz.Services.Contracts
{
    public interface IQuizThemeService
    {
        Task<PagedResult<QuizThemeResponse>> GetPageAsync(QuizThemeRequest request);
        Task<QuizThemeResponse> GetByIdAsync(int id);

        Task<int> DeleteByIdAsync(int id);
        Task<int> PutQuizTheme(QuizTheme item);
        Task<QuizTheme> FindAsync(int id);
        Task<QuizTheme> PostQuizTheme(QuizTheme item);
    }
}