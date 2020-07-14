using System.Threading.Tasks;
using PubQuiz.Requests;
using PubQuiz.Responses;
using PubQuiz.DB;
using PubQuiz.Shared.Pagination;
using System.Linq;
using PubQuiz.Shared.Extensions;
using PubQuiz.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using PubQuiz.Services;
using PubQuiz.Models;

namespace PubQuiz.Services
{
    public class QuizThemeService : BaseService, IQuizThemeService
    {
        private readonly PubQuizContext _context;

        public QuizThemeService(
            PubQuizContext context
        )
        {
            _context = context;
        }

        public async Task<PagedResult<QuizThemeResponse>> GetPageAsync(QuizThemeRequest request)
        {
            PagedResult<QuizThemeResponse> pagedResult = await _context
                .QuizThemes.AsQueryable()
                .Select(i => new QuizThemeResponse
                {
                    Id = i.Id,
                    Name = i.Name


                })
                .ToPagedResultAsync(request);

            return pagedResult;
        }

        public async Task<QuizThemeResponse> GetByIdAsync(int id)
        {
            return await _context
                .QuizThemes
                .Select(i => new QuizThemeResponse
                {
                    Id = i.Id,
                    Name = i.Name
                })
                .FirstAsync();
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            var quizTheme = await _context
                .QuizThemes
                .FindAsync(id);

            _context.QuizThemes.Remove(quizTheme);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> PutQuizTheme(QuizTheme item)
        {
            _context.Entry(item).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }


        public async Task<QuizTheme> FindAsync(int id)
        {
            return await _context.QuizThemes.FindAsync(id);
        }

        public async Task<QuizTheme> PostQuizTheme(QuizTheme item)
        {
            _context.QuizThemes.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

    }
}


