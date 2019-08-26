using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentiProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace StudentiProject.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly DB.StudentiProjectContext _context;

        public CourseController(DB.StudentiProjectContext context)
        {
            _context = context;

            
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourseItem()
        {
            return await _context.Courses
                 .Include(c => c.Division)
                 .ToListAsync();


        }


        //GET

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourseItem(int id)
        {
            var CourseItem = await _context.Courses.FindAsync(id);

            if (CourseItem == null)
            {
                return NotFound();
            }

            return CourseItem;
        }


        // POST

        [HttpPost]
        public async Task<IActionResult> PostCourseItem(Course item)
        {
            if (!ModelState.IsValid)

            {
                return ValidationProblem(ModelState);
            }
            _context.Courses.Add(item);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }

        // PUT
        [HttpPut("{Id}")]
        public async Task<IActionResult> PutCourseItem(int Id, [FromBody] Course item)
        {
            item.Id = Id;

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var CourseItem = await _context.Courses.FindAsync(id);

            if (CourseItem == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(CourseItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}