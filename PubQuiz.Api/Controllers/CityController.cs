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
    [Route("api/cities")]
    [ApiController]

    public class CityController : BaseController
    {
        private readonly ICityService Cities;

        public CityController(ICityService cities)
        {
            Cities = cities;
        }

        [HttpGet]
        public async Task<IActionResult> GetPage([FromQuery] CityRequest request = null)
        {
            PagedResult<CityResponse> pagedResult = await Cities.GetPageAsync(request);
            return ApiOk(pagedResult);
        }



        // GET
        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetCityItem(int id)
        {
            var CityItem = await Cities.FindAsync(id);

            if (CityItem == null)
            {
                return NotFound();
            }

            return CityItem;
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> Postcityitem(City item)
        {

            return ApiOk(await Cities.PostCity(item));
        }




        /*        [HttpPost]
                public async Task<iactionresult> postcityitem(city item)
                {
                    if (!modelstate.isvalid)

                    {
                        return validationproblem(modelstate);
                    }
                    _context.cities.add(item);
                    await _context.savechangesasync();
                    return statuscode(201);
                }*/

        [HttpPut("{Id}")]
        public async Task<int> PutCityItem(int Id, [FromBody] City item)
        {
            item.Id = Id;
            return await Cities.PutCity(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int success = await Cities.DeleteByIdAsync(id);
            return ApiOk(success);
        }

        // DELETE

        /*       [HttpDelete("{Id}")]
               public async Task<IActionResult> DeleteCity(int Id)
               {
                   var CityItem = await _context.Cities.FindAsync(Id);

                   if (CityItem == null)
                   {
                       return NotFound();
                   }

                   _context.Cities.Remove(CityItem);
                   await _context.SaveChangesAsync();

                   return NoContent();
               }
       */
    }
}