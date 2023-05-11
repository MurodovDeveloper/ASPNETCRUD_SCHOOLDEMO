using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class StudentTeacher
    {
        public int StudentteacherId { get; set; }
        public Student Student { get; set; }
        public Teacher Teacher { get; set;}
    }
}
