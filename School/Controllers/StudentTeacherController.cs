using Application.Abstraction;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentTeacherController : ControllerBase
    {
        private readonly IApplicationDbContext _context;

        public StudentTeacherController(IApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<StudentTeacher>>> Get()
        {
            return Ok(await _context.studentTeachers.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentTeacher>> Get(int id)
        {
            var hero = await _context.studentTeachers.FindAsync(id);
            if (hero == null)
                return BadRequest("Student not found.");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<StudentTeacher>>> AddHero(StudentTeacher hero)
        {
            _context.studentTeachers.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(await _context.students.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<StudentTeacher>>> UpdateHero(StudentTeacher request)
        {
            var dbHero = await _context.studentTeachers.FindAsync(request.StudentteacherId);
            if (dbHero == null)
                return BadRequest("Student not found.");
            dbHero.StudentteacherId = request.StudentteacherId;



            await _context.SaveChangesAsync();

            return Ok(await _context.studentTeachers.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<StudentTeacher>>> Delete(int id)
        {
            var dbHero = await _context.studentTeachers.FindAsync(id);
            if (dbHero == null)
                return BadRequest("Student not found.");

            _context.studentTeachers.Remove(dbHero);
            await _context.SaveChangesAsync();

            return Ok(await _context.studentTeachers.ToListAsync());
        }
    }
}
