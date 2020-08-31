using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PubQuiz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PubQuiz.Shared.Pagination;
using PubQuiz.Requests;
using PubQuiz.Responses;
using PubQuiz.Services.Contracts;

namespace PubQuiz.Controllers
{
    [Route("api/champions")]
    [ApiController]

    public class ChampionController : BaseController
    {
        private readonly IChampionService Champions;

        public ChampionController(IChampionService champions)
        {
            Champions = champions;
        }

        [HttpGet]
        [Route("getChampions")]
        public async Task<IActionResult> GetPage([FromQuery] ChampionRequest request = null)
        {
            PagedResult<ChampionResponse> pagedResult = await Champions.GetPageAsync(request);
            return ApiOk(pagedResult);
        }



        // GET
        [HttpGet("{id}")]
        public async Task<ActionResult<Champion>> GetChampionItem(int id)
        {
            var ChampionItem = await Champions.FindAsync(id);

            if (ChampionItem == null)
            {
                return NotFound();
            }

            return ChampionItem;
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> Postchampionitem(Champion item)
        {

            return ApiOk(await Champions.PostChampion(item));
        }


        [HttpPut("{Id}")]
        public async Task<int> PutChampionItem(int Id, [FromBody] Champion item)
        {
            item.Id = Id;
            return await Champions.PutChampion(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int success = await Champions.DeleteByIdAsync(id);
            return ApiOk(success);
        }
    }
}