using Application.Abstraction;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.DataAcces
{
    public class AppDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Student> students { get; set; }
        public DbSet<Teacher> teachers { get; set; }
        public DbSet<StudentTeacher> studentTeachers{get;set;}
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    }
}
