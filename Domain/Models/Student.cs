using Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("student")]
    public class Student
    {

        [Column("student_id")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
        [Column("student_name")]
        public required string FullName { get; set; }
        [Column("student_birthdate")]
        public DateTime BirthDate { get; set; }
        [Column("student_gender")]
        public Gender Gender { get; set; }
        public List<StudentTeacher> StudentTeachers { get; set; } 
    }
}