using LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Repository
{
    public interface IStandardTeacherRepository
    {
        bool AddTeacher(StandardTeacherModel model);
        bool RemoveTeeacher(StandardTeacherModel model);
        bool Save();
    }
}
