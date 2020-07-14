using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PubQuiz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PubQuiz.Services.Contracts;
using PubQuiz.Requests;
using PubQuiz.Responses;
using PubQuiz.Shared.Pagination;

namespace PubQuiz.Controllers
{
    [Route("api/quizThemes")]
    [ApiController]
    public class QuizThemeController : BaseController
    {
        private readonly IQuizThemeService QuizThemes;

        public QuizThemeController(IQuizThemeService quizThemes)
        {
            QuizThemes = quizThemes;
        }

        [HttpGet]
        public async Task<IActionResult> GetPage([FromQuery] QuizThemeRequest request = null)
        {
            PagedResult<QuizThemeResponse> pagedResult = await QuizThemes.GetPageAsync(request);
            return ApiOk(pagedResult);
        }



        // GET
        [HttpGet("{id}")]
        public async Task<ActionResult<QuizTheme>> GetQuizThemeItem(int id)
        {
            var QuizThemeItem = await QuizThemes.FindAsync(id);

            if (QuizThemeItem == null)
            {
                return NotFound();
            }

            return QuizThemeItem;
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> PostquizThemeitem(QuizTheme item)
        {
            return ApiOk(await QuizThemes.PostQuizTheme(item));
        }

        //PUT

        [HttpPut("{Id}")]
        public async Task<int> PutQuizThemeItem(int Id, [FromBody] QuizTheme item)
        {
            item.Id = Id;
            return await QuizThemes.PutQuizTheme(item);
        }

        // DELETE

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int success = await QuizThemes.DeleteByIdAsync(id);
            return ApiOk(success);
        }

    }
}