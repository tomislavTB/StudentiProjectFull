using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentiProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentiProject.Requests;

namespace StudentiProject.Controllers
{
    [Route("api/grades")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly DB.StudentiProjectContext _context;

        public GradeController(DB.StudentiProjectContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Grade>>> GetGradeItem()
        {

            return await _context.Grades
                .Include(c => c.Student)
                .Include(c => c.Course)

                .ToListAsync();
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Grade>> GetGradeItem(int id)
        {
            var GradeItem = await _context.Grades.FindAsync(id);

            if (GradeItem == null)
            {
                return NotFound();
            }

            return GradeItem;
        }
        [HttpPost]
        public async Task<IActionResult> PostGradeItem(GradeInsertRequest request)
        {
            _context.Grades.Add(new Grade {
                Evaluation = request.Evaluation,
                CourseId = request.CourseId,
                StudentId = request.StudentId
            });
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }

        // PUT: api/Todo/5
        [HttpPut("{Id}")]
        public async Task<IActionResult> PutGradeItem(int Id, [FromBody] Grade item)
        {
            item.Id = Id;

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteGrade(int id)
        {
            var GradeItem = await _context.Grades.FindAsync(id);

            if (GradeItem == null)
            {
                return NotFound();
            }

            _context.Grades.Remove(GradeItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}