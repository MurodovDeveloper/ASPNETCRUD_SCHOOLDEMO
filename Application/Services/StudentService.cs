using Application.Abstraction;
using Domain.Models;

namespace Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IApplicationDbContext _dbcontext;
        public StudentService(IApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<bool> AddAsync(Student entity)
        {
            await _dbcontext.students.AddAsync(entity);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddRangeAsync(IQueryable<Student> entities)
        {
            await _dbcontext.students.AddRangeAsync(entities);
            await _dbcontext.SaveChangesAsync();
            return true;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            Student? student = _dbcontext.students.FirstOrDefault(x => x.StudentId == id);
            _dbcontext.students.Remove(student);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public Task<IQueryable<Student>> GetAllAsync()
        {
            IQueryable<Student> queryable = _dbcontext.students.AsQueryable();
            return Task.FromResult(queryable);
        }

        public Task<Student> GetByIdAsync(int id)
        {
            Student? student = _dbcontext.students.FirstOrDefault(x => x.StudentId == id);
            return Task.FromResult(student);
        }
        public async Task<bool> UpdateAsync(Student entity)
        {
            _dbcontext.students.Update(entity);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
}
