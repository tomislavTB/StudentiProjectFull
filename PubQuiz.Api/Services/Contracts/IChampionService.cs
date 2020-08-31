using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PubQuiz.Models;
using PubQuiz.Requests;
using PubQuiz.Responses;
using PubQuiz.Shared.Pagination;

namespace PubQuiz.Services.Contracts
{
    public interface IChampionService
    {
        Task<PagedResult<ChampionResponse>> GetPageAsync(ChampionRequest request);
        Task<ChampionResponse> GetByIdAsync(int id);

        Task<int> DeleteByIdAsync(int id);
        Task<int> PutChampion(Champion item);
        Task<Champion> FindAsync(int id);
        Task<Champion> PostChampion(Champion item);
    }
}