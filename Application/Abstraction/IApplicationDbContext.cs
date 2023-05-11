using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction
{
    public interface IApplicationDbContext
    {
        DbSet<Student> students { get; set; }
        DbSet<Teacher> teachers { get; set; }
        DbSet<StudentTeacher> studentTeachers { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
