using Application.Abstraction;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace School.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class TeacherController : ControllerBase
        {
            private readonly IApplicationDbContext _context;

            public TeacherController(IApplicationDbContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<ActionResult<List<Teacher>>> Get()
            {
                return Ok(await _context.teachers.ToListAsync());
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Teacher>> Get(int id)
            {
                var hero = await _context.teachers.FindAsync(id);
                if (hero == null)
                    return BadRequest("Teacher not found.");
                return Ok(hero);
            }

            [HttpPost]
            public async Task<ActionResult<List<Teacher>>> AddHero(Teacher hero)
            {
                _context.teachers.Add(hero);
                await _context.SaveChangesAsync();

                return Ok(await _context.teachers.ToListAsync());
            }

            [HttpPut]
            public async Task<ActionResult<List<Teacher>>> UpdateHero(Teacher request)
            {
                var dbHero = await _context.teachers.FindAsync(request.TeacherId);
                if (dbHero == null)
                    return BadRequest("Teacher not found.");
                dbHero.TeacherId = request.TeacherId;
                dbHero.FullName = request.FullName;
                dbHero.Gender = request.Gender;
                dbHero.BirthDate = request.BirthDate;


                await _context.SaveChangesAsync();

                return Ok(await _context.teachers.ToListAsync());
            }

            [HttpDelete("{id}")]
            public async Task<ActionResult<List<Student>>> Delete(int id)
            {
                var dbHero = await _context.teachers.FindAsync(id);
                if (dbHero == null)
                    return BadRequest("Teacher not found.");

                _context.teachers.Remove(dbHero);
                await _context.SaveChangesAsync();

                return Ok(await _context.teachers.ToListAsync());
            }
        }
}
