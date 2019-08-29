using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentiProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace StudentiProject.Controllers
{
    [Route("api/executors")]
    [ApiController]
    public class ExecutorController : ControllerBase
    {
        private readonly DB.StudentiProjectContext _context;

        public ExecutorController(DB.StudentiProjectContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Executor>>> GetExecutorItem()
        {
            return await _context.Executors
                .Include(c => c.Teacher)
                .Include(c => c.Course)
                .ToListAsync();
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Executor>> GetExecutorItem(int id)
        {
            var ExecutorItem = await _context.Executors.FindAsync(id);

            if (ExecutorItem == null)
            {
                return NotFound();
            }

            return ExecutorItem;
        }
        [HttpPost]
        public async Task<IActionResult> PostExecutorItem(Executor item)
        {
            if (!ModelState.IsValid)

            {
                return ValidationProblem(ModelState);
            }
            _context.Executors.Add(item);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }

        // PUT: api/Todo/5
        [HttpPut("{Id}")]
        public async Task<IActionResult> PutExecutorItem(int Id, [FromBody] Executor item)
        {
            item.Id = Id;

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteExecutor(int id)
        {
            var ExecutorItem = await _context.Executors.FindAsync(id);

            if (ExecutorItem == null)
            {
                return NotFound();
            }

            _context.Executors.Remove(ExecutorItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}