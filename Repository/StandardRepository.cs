using LMS.Data;
using LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Repository
{
    public class StandardRepository : IStandardRepository
    {
        private readonly dbContext context;
        public StandardRepository(dbContext dbContext)
        {
            context = dbContext;
        }

        public bool AddStandard(StandardModel model)
        {
            var standard = new Standard()
            {
                Id = model.Id,
                Name = model.Name
            };
            context.Standard.Add(standard);
            return Save();
        }

        public bool DeleteStandard(int id)
        {
            var standard = context.Standard.Find(id);
            context.Standard.Remove(standard);
            return Save();
        }

        public StandardModel GetStandard(int id)
        {
            var data = context.Standard.Find(id);
           var model = new StandardModel()
            {
                Id = data.Id,
                Name = data.Name
            };
            return model;
        }

        public ICollection<StandardModel> GetStandards()
        {
            return context.Standard.Select(item => new StandardModel()
            {
                Id = item.Id,
                Name = item.Name
            }).ToList();
            
        }

        public List<Teacher> GetTeacherByClass(int standardId)
        {
            return context.StandardTeachers.Where(x => x.Standard.Id == standardId).Select(x => x.Teacher).ToList();
        }

        public bool IsExist(int id)
        {
            return context.Standard.Any(x => x.Id == id);
        }

        public bool Save()
        {
            var save = context.SaveChanges();
            return save > 0 ? true : false;
        }

        public bool UpdateStandard(StandardModel model)
        {
            var standard = new Standard()
            {
                Id = model.Id,
                Name = model.Name
            };
            context.Standard.Update(standard);
            return Save();
        }
    }
}
