using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Data
{
    public class StandardTeacher
    {
        public int StandardId { get; set; }
        public int TeacherId { get; set; }
        public Standard Standard { get; set; }
        public Teacher Teacher { get; set; }
    }
}
