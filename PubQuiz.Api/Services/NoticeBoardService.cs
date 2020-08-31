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
using System.Security.Claims;
using PubQuiz.Model.Users;
using System.Linq;

namespace PubQuiz.Services
{
    public class NoticeBoardService : BaseService, INoticeBoardService
    {
        private readonly PubQuizContext _context;

        public NoticeBoardService(
            PubQuizContext context
        )
        {
            _context = context;
        }

        public async Task<PagedResult<NoticeBoardResponse>> GetPageAsync(long userId, NoticeBoardRequest request = null)
        {

            if (userId > 0)
            {
                PagedResult<NoticeBoardResponse> pagedResult = await _context

                .NoticeBoards.AsQueryable().Include(a => a.Country).Include(a => a.City).Include(a => a.QuizTheme).Include(a => a.AuthUser).Where(a => a.AuthUser.Id == userId)
                .Select(i => new NoticeBoardResponse

            {
                    Id = i.Id,
                    Name = i.Name,
                    DateWhen = i.DateWhen,
                    CityId = i.CityId,
                    AuthUserId = i.AuthUserId,
                    AuthUser = i.AuthUser,
                    Country = i.Country,
                    CountryId = i.CountryId,
                    City = i.City,
                    QuizThemeId = i.QuizThemeId,
                    QuizTheme = i.QuizTheme




                })
                .ToPagedResultAsync(request);
                            return pagedResult;
                        }
                        else
                        {
                            PagedResult<NoticeBoardResponse> pagedResult = await _context

                .NoticeBoards.AsQueryable().Include(a => a.Country).Include(a => a.City).Include(a => a.QuizTheme).Include(a => a.AuthUser)
                .Select(i => new NoticeBoardResponse

                {
                    Id = i.Id,
                    Name = i.Name,
                    DateWhen = i.DateWhen,
                    CityId = i.CityId,
                    AuthUserId = i.AuthUserId,
                    AuthUser = i.AuthUser,
                    Country = i.Country,
                    CountryId = i.CountryId,
                    City = i.City,
                    QuizThemeId = i.QuizThemeId,
                    QuizTheme = i.QuizTheme




                })
                .ToPagedResultAsync(request);
                            return pagedResult;
                        }
            //var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);


        }

        public async Task<NoticeBoardResponse> GetByIdAsync(int id)
        {
            return await _context
                .NoticeBoards
                .Select(i => new NoticeBoardResponse
                {
                    Id = i.Id,
                    Name = i.Name,
                    DateWhen = i.DateWhen,
                    CityId = i.CityId,
                    AuthUserId = i.AuthUserId,
                    Country = i.Country,
                    CountryId = i.CountryId,
                    City = i.City,
                    QuizThemeId = i.QuizThemeId,
                    QuizTheme = i.QuizTheme

                })
                .FirstAsync();
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            var noticeBoard = await _context
                .NoticeBoards
                .FindAsync(id);

            _context.NoticeBoards.Remove(noticeBoard);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> PutNoticeBoard(NoticeBoard item)
        {
            _context.Entry(item).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }


        public async Task<NoticeBoard> FindAsync(int id)
        {
            return await _context.NoticeBoards.FindAsync(id);
        }

        public async Task<NoticeBoard> PostNoticeBoard(NoticeBoard item)
        {
            _context.NoticeBoards.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

    }
}


