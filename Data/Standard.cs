using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Data
{
    public class Standard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Student> Student { get; set; }
        public ICollection<StandardTeacher> StandardTeachers { get; set; }
    }
}
