using LMS.Data;
using LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly dbContext context;

        public TeacherRepository(dbContext context)
        {
            this.context = context;
        }
        public bool AddTeacher(TeacherModel teacher)
        {
            var newTeacher = new Teacher()
            {
                Name = teacher.Name,
                Adress = teacher.Adress,
                Phone = teacher.Phone
            };
            context.Teachers.Add(newTeacher);
            return Save();
        }

        public bool DeleteTeacher(int id)
        {
            var teacher = context.Teachers.Find(id);
            context.Teachers.Remove(teacher);
            return Save();
        }

        public TeacherModel GetTeacher(int id)
        {
            var data = context.Teachers.Find(id);
            var teacher = new TeacherModel()
            {
                Id = data.Id,
                Name = data.Name,
                Adress = data.Adress,
                Phone = data.Phone
            };
            return teacher;
        }

        public ICollection<TeacherModel> GetTeachers()
        {
            var data = context.Teachers.ToList();
            var teachers = new List<TeacherModel>();
            foreach (var item in data)
            {
                var teacher = new TeacherModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Phone = item.Phone,
                    Adress = item.Adress
                };
                teachers.Add(teacher);
            }
            return teachers;
        }

        public bool IsExist(int id)
        {
            return context.Teachers.Any(x => x.Id == id);
        }

        public bool UpdateTeacher(TeacherModel teacher)
        {
            var newTeacher = new Teacher()
            {
                Id = teacher.Id,
                Name = teacher.Name,
                Adress = teacher.Adress,
                Phone = teacher.Phone
            };
            context.Teachers.Update(newTeacher);
            return Save();
        }
        public bool Save()
        {
            var save = context.SaveChanges();
            return save > 0 ? true : false;
        }

        public List<Standard> GetStandardByTeacher(int teacherId)
        {
            var data = context.StandardTeachers.Where(x => x.Teacher.Id == teacherId).Select(x => x.Standard).ToList();
            return data;
        }
    }
}
