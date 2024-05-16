using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LMS.Data;

namespace LMS.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required][Display(Name ="Father Name")]
        public string FatherName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required][StringLength(13,MinimumLength =13, ErrorMessage ="Please enter the valid CNIC number")]
        public string CNIC { get; set; }
        [Display(Name = "Class")]
        public int StandardId { get; set; }
        public string Standard { get; set; }
    }
}
