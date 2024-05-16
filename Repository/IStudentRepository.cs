using LMS.Data;
using LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Repository
{
    public interface IStudentRepository
    {
        bool Add(StudentModel student);
        ICollection<StudentModel> GetStudents(int? standard = null);
        StudentModel GetStudent(int id);
        bool UpdateStudent(StudentModel model);
        bool DeleteStudent(int id);
        bool IsExist(string cnic);
    }
}
