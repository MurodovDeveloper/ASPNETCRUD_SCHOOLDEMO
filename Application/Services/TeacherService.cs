using Application.Abstraction;
using Domain.Models;

namespace Application.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IApplicationDbContext _dbcontext;

        public async Task<bool> AddAsync(Teacher entity)
        {
            await _dbcontext.teachers.AddAsync(entity);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddRangeAsync(IQueryable<Teacher> entities)
        {
            await _dbcontext.teachers.AddRangeAsync(entities);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Teacher? teacher = _dbcontext.teachers.FirstOrDefault(x => x.TeacherId == id);
            _dbcontext.teachers.Remove(teacher);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public Task<IQueryable<Teacher>> GetAllAsync()
        {
            IQueryable<Teacher> queryable = _dbcontext.teachers;
            return Task.FromResult(queryable);
        }

        public Task<Teacher> GetByIdAsync(int id)
        {
            Teacher? teacher = _dbcontext.teachers.FirstOrDefault(x => x.TeacherId == id);
            return Task.FromResult(teacher);

        }

        public async Task<bool> UpdateAsync(Teacher entity)
        {
            _dbcontext.teachers.Update(entity);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
}
