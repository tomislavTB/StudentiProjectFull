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
using Microsoft.AspNetCore.Mvc;

namespace PubQuiz.Services
{
    public class ChampionService : BaseService, IChampionService
    {
        private readonly PubQuizContext _context;

        public ChampionService(
            PubQuizContext context
        )
        {
            _context = context;
        }

        public async Task<PagedResult<ChampionResponse>> GetPageAsync(ChampionRequest request)
        {
            PagedResult<ChampionResponse> pagedResult = await _context
                .Champion.AsQueryable().Include(r => r.NoticeBoard).Include(r => r.NoticeBoard.AuthUser).Include(r => r.NoticeBoard.QuizTheme).Include(r => r.NoticeBoard.Country).Include(r => r.NoticeBoard.City)
                .Select(i => new ChampionResponse
                {
                    Id = i.Id,
                    NoticeBoardId = i.NoticeBoardId,
                    NoticeBoard = i.NoticeBoard,
                    AuthUser = i.NoticeBoard.AuthUser.Email,
                    Name = i.Name

                })
                .ToPagedResultAsync(request);

            return pagedResult;
        }

        public async Task<ChampionResponse> GetByIdAsync(int id)
        {
            return await _context
                .Champion
                .Select(i => new ChampionResponse
                {
                    Id = i.Id,
                    NoticeBoardId = i.NoticeBoardId

                })
                .FirstAsync();
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            var champion = await _context
                .Champion
                .FindAsync(id);

            _context.Champion.Remove(champion);
            return await _context.SaveChangesAsync();
        }

        public async Task<Champion> FindAsync(int id)
        {
            return await _context.Champion.FindAsync(id);
        }

        public async Task<int> PutChampion(Champion item)
        {
            _context.Entry(item).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }


        public async Task<Champion> PostChampion(Champion item)
        {
            _context.Champion.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}
