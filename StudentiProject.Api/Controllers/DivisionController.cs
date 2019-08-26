using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentiProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace StudentiProject.Controllers
{
    [Route("api/divisions")]
    [ApiController]
    public class DivisionController : ControllerBase
    {
        private readonly DB.StudentiProjectContext _context;

        public DivisionController(DB.StudentiProjectContext context)
        {
            _context = context;

         
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Division>>> GetDivisionItem()
        {
            return await _context.Divisions.ToListAsync();
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Division>> GetDivisionItem(int id)
        {
            var DivisionItem = await _context.Divisions.FindAsync(id);

            if (DivisionItem == null)
            {
                return NotFound();
            }

            return DivisionItem;
        }
        [HttpPost]
        public async Task<IActionResult> PostDivisionItem(Division item)
        {
            if (!ModelState.IsValid)

            {
                return ValidationProblem(ModelState);
            }
            _context.Divisions.Add(item);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }

        // PUT: api/Todo/5
        [HttpPut("{Id}")]
        public async Task<IActionResult> PutDivisionItem(int Id, [FromBody] Division item)
        {
            item.Id = Id;

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteDivision(int id)
        {
            var DivisionItem = await _context.Divisions.FindAsync(id);

            if (DivisionItem == null)
            {
                return NotFound();
            }

            _context.Divisions.Remove(DivisionItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}