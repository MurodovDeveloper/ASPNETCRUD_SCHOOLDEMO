using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enum;

namespace Domain.Models
{
    [Table("teacher")]
    public class Teacher
    {
        [Column("teacher_id")]
        public int TeacherId { get; set; }
        [Column("teacher_name")]
        public required string FullName { get; set; }
        [Column("teacher_birthdate")]
        public DateTime BirthDate { get; set; }
        [Column("teacher_gender")]
        public Gender Gender { get; set; }
        public List<StudentTeacher> StudentTeachers { get; set; }
    }
}
