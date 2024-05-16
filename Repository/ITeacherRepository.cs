using LMS.Data;
using LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Repository
{
    public interface ITeacherRepository
    {
        bool AddTeacher(TeacherModel teacher);
        ICollection<TeacherModel> GetTeachers();
        TeacherModel GetTeacher(int id);
        bool UpdateTeacher(TeacherModel teacher);
        bool DeleteTeacher(int id);
        bool IsExist(int id);
        bool Save();
        List<Standard> GetStandardByTeacher(int teacherId);
    }
}
