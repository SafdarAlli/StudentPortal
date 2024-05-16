using LMS.Data;
using LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly dbContext context;
        public StudentRepository(dbContext dbContext)
        {
            context = dbContext;
        }
        public bool Add(StudentModel model)
        {
            var student = new Student()
            {
                Name = model.Name,
                FatherName = model.FatherName,
                Address = model.Address,
                CNIC = model.CNIC,
                StandardId = model.StandardId
            };
            context.Student.Add(student);
            context.SaveChanges();
            return true;
        }

        public bool DeleteStudent(int id)
        {
            var student = context.Student.Find(id);
            context.Student.Remove(student);
            context.SaveChanges();
            return true;
        }

        public StudentModel GetStudent(int id)
        {
            var data = context.Student.Find(id);
            var student = new StudentModel()
            {
                Id = data.Id,
                Name = data.Name,
                FatherName = data.FatherName,
                CNIC = data.CNIC,
                Address = data.Address,
                StandardId = data.StandardId
            };
            return student;
        }

        public ICollection<StudentModel> GetStudents(int? standard = null)
        {
            var students = new List<StudentModel>();
            if (standard == 0 || standard == null)
            {
                var data = context.Student.ToList();
                foreach (var item in data)
                {
                    var student = new StudentModel()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        FatherName = item.FatherName,
                        CNIC = item.CNIC,
                        Address = item.Address,
                        StandardId = item.StandardId
                    };
                    students.Add(student);
                }
                return students;
            }
            else
            {
                var data = context.Student.Where(x => x.StandardId == standard).ToList();
                foreach (var item in data)
                {
                    var student = new StudentModel()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        FatherName = item.FatherName,
                        CNIC = item.CNIC,
                        Address = item.Address,
                        StandardId = item.StandardId
                    };
                    students.Add(student);
                }
                return students;
            }
        }

        public bool IsExist(string cnic)
        {
            return context.Student.Any(x => x.CNIC == cnic);
        }

        public bool UpdateStudent(StudentModel model)
        {
            var student = new Student()
            {
                Id = model.Id,
                Name = model.Name,
                FatherName = model.FatherName,
                CNIC = model.CNIC,
                Address = model.Address,
                StandardId = model.StandardId
            };
            context.Student.Update(student);
            context.SaveChanges();
            return true;
        }
    }
}
