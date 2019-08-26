using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentiProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace StudentiProject.Controllers
{
    [Route("api/teachers")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly DB.StudentiProjectContext _context;

        public TeacherController(DB.StudentiProjectContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeacherItem()
        {
            return await _context.Teachers
                .ToListAsync();
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetTeacherItem(int id)
        {
            var TeacherItem = await _context.Teachers.FindAsync(id);

            if (TeacherItem == null)
            {
                return NotFound();
            }

            return TeacherItem;
        }
        [HttpPost]
        public async Task<IActionResult> PostTeacherItem(Teacher item)
        {
            if (!ModelState.IsValid)

            {
                return ValidationProblem(ModelState);
            }
            _context.Teachers.Add(item);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }

        // PUT: api/Todo/5
        [HttpPut("{Id}")]
        public async Task<IActionResult> PutTeacherItem(int Id, [FromBody] Teacher item)
        {
            item.Id = Id;

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var TeacherItem = await _context.Teachers.FindAsync(id);

            if (TeacherItem == null)
            {
                return NotFound();
            }

            _context.Teachers.Remove(TeacherItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}