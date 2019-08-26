using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentiProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentiProject.Services.Contracts;
using StudentiProject.Requests;
using StudentiProject.Responses;
using StudentiProject.Shared.Pagination;

namespace StudentiProject.Controllers
{
    [Route("api/colleges")]
    [ApiController]
    public class CollegeController : BaseController
    {
        private readonly ICollegeService Colleges;

        public CollegeController(ICollegeService colleges)
        {
            Colleges = colleges;
        }

        [HttpGet]
        public async Task<IActionResult> GetPage([FromQuery] CollegePaginationRequest request = null)
        {
            PagedResult<CollegeResponse> pagedResult = await Colleges.GetPageAsync(request);
            return ApiOk(pagedResult);
        }



        // GET
        [HttpGet("{id}")]
        public async Task<ActionResult<College>> GetCollegeItem(int id)
        {
            var CollegeItem = await Colleges.FindAsync(id);

            if (CollegeItem == null)
            {
                return NotFound();
            }

            return CollegeItem;
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> Postcollegeitem(College item)
        {
            return ApiOk(await Colleges.PostCollege(item));
        }

        //PUT

        [HttpPut("{Id}")]
        public async Task<int> PutCollegeItem(int Id, [FromBody] College item)
        {
            item.Id = Id;
            return await Colleges.PutCollege(item);
        }

        // DELETE

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int success = await Colleges.DeleteByIdAsync(id);
            return ApiOk(success);
        }

    }
}