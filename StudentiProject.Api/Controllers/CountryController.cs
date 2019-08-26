using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentiProject.DB;
using StudentiProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentiProject.Controllers;
using StudentiProject.Services.Contracts;
using StudentiProject.Requests;
using StudentiProject.Responses;
using StudentiProject.Shared.Pagination;

namespace StudentiProject.Controllers
{

    [Route("api/countries")]
    [ApiController]
    public class CountryController : BaseController
    {
        private readonly ICountryService Countries;

        public CountryController(ICountryService countries)
        {
            Countries = countries;
        }

        [HttpGet]
        public async Task<IActionResult> GetPage([FromQuery] CountryPaginationRequest request = null)
        {
            PagedResult<CountryResponse> pagedResult = await Countries.GetPageAsync(request);
            return ApiOk(pagedResult);
        }



        // GET
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetountryItem(int id)
        {
            var CountryItem = await Countries.FindAsync(id);

            if (CountryItem == null)
            {
                return NotFound();
            }

            return CountryItem;
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> Postcountryitem(Country item)
        {
            return ApiOk(await Countries.PostCountry(item));
        }

        [HttpPut("{Id}")]
        public async Task<int> PutCountryItem(int Id, [FromBody] Country item)
        {
            item.Id = Id;
            return await Countries.PutCountry(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int success = await Countries.DeleteByIdAsync(id);
            return ApiOk(success);
        }
    }
}