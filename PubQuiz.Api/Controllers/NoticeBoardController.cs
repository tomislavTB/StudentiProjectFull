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
    [Route("api/noticeBoards")]
    [ApiController]
    public class NoticeBoardController : BaseController
    {
        private readonly INoticeBoardService NoticeBoards;

        public NoticeBoardController(INoticeBoardService noticeBoards)
        {
            NoticeBoards = noticeBoards;
        }

        [HttpGet]
        [Route("getNoticeboards")]
        public async Task<IActionResult> GetPage([FromQuery] NoticeBoardRequest request = null)
        {
            PagedResult<NoticeBoardResponse> pagedResult = await NoticeBoards.GetPageAsync(0, request);
            return ApiOk(pagedResult);
        }

        [HttpPost]
        [Route("getNoticeboardsPost")]
        public async Task<IActionResult> GetPage2([FromBody] NoticeBoardRequest request = null)
        {
            PagedResult<NoticeBoardResponse> pagedResult = await NoticeBoards.GetPageAsync(request.userId, request);
            return ApiOk(pagedResult);
        }



        // GET
        [HttpGet("{id}")]
        public async Task<ActionResult<NoticeBoard>> GetNoticeBoardItem(int id)
        {
            var NoticeBoardItem = await NoticeBoards.FindAsync(id);

            if (NoticeBoardItem == null)
            {
                return NotFound();
            }

            return NoticeBoardItem;
        }

        // POST
        [HttpPost]
        [Route("noticeBoards")]
        public async Task<IActionResult> PostNoticeBoarditem([FromBody]NoticeBoard item)
        {
            return ApiOk(await NoticeBoards.PostNoticeBoard(item));
        }

        //PUT

        [HttpPut("{Id}")]
        public async Task<int> PutNoticeBoardItem(int Id, [FromBody] NoticeBoard item)
        {
            item.Id = Id;
            return await NoticeBoards.PutNoticeBoard(item);
        }

        // DELETE

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int success = await NoticeBoards.DeleteByIdAsync(id);
            return ApiOk(success);
        }

    }
}