using LMS.Data;
using LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Repository
{
    public class StandardTeacherRepository : IStandardTeacherRepository
    {
        private readonly dbContext context;

        public StandardTeacherRepository(dbContext context)
        {
            this.context = context;
        }
        public bool AddTeacher(StandardTeacherModel model)
        {
            var standarTeacher = new StandardTeacher()
            {
                StandardId = model.StandardId,
                TeacherId = model.TeacherId
            };
            context.StandardTeachers.Add(standarTeacher);
            return Save();
        }

        public bool RemoveTeeacher(StandardTeacherModel model)
        {
            var standardTeacher = new StandardTeacher()
            {
                StandardId = model.StandardId,
                TeacherId = model.TeacherId
            };
            context.StandardTeachers.Remove(standardTeacher);
            return Save();
        }

        public bool Save()
        {
            var save = context.SaveChanges();
            return save > 0 ? true : false;
        }
    }
}
