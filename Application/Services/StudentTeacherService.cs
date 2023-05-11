using Application.Abstraction;
using Domain.Models;

namespace Application.Services
{
    public class StudentTeacherService : IStudentTeacherServices
    {
        private readonly IApplicationDbContext _dbcontext;

        public StudentTeacherService(IApplicationDbContext db)
        {
            _dbcontext = db;
        }

        public async Task<bool> AddAsync(StudentTeacher entity)
        {
            await _dbcontext.studentTeachers.AddAsync(entity);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddRangeAsync(IQueryable<StudentTeacher> entities)
        {
            await _dbcontext.studentTeachers.AddRangeAsync(entities);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<StudentTeacher>> GetAllAsync()
        {
            IQueryable<StudentTeacher> queryable = _dbcontext.studentTeachers;
            return Task.FromResult(queryable);
        }

        public Task<StudentTeacher> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(StudentTeacher entity)
        {
            _dbcontext.studentTeachers.Update(entity);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
}
