using Application.Abstraction;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace School.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IApplicationDbContext _context;

        public StudentController(IApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> Get()
        {
            return Ok(await _context.students.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> Get(int id)
        {
            var hero = await _context.students.FindAsync(id);
            if (hero == null)
                return BadRequest("Student not found.");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<Student>>> AddHero(Student hero)
        {
            _context.students.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(await _context.students.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Student>>> UpdateHero(Student request)
        {
            var dbHero = await _context.students.FindAsync(request.StudentId);
            if (dbHero == null)
                return BadRequest("Student not found.");
            dbHero.StudentId = request.StudentId;
            dbHero.FullName = request.FullName;
            dbHero.Gender = request.Gender;
            dbHero.BirthDate = request.BirthDate;


            await _context.SaveChangesAsync();

            return Ok(await _context.students.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Student>>> Delete(int id)
        {
            var dbHero = await _context.students.FindAsync(id);
            if (dbHero == null)
                return BadRequest("Student not found.");

            _context.students.Remove(dbHero);
            await _context.SaveChangesAsync();

            return Ok(await _context.students.ToListAsync());
        }
    }
}
