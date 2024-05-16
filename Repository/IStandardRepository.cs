using LMS.Data;
using LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Repository
{
    public interface IStandardRepository
    {
        bool AddStandard(StandardModel model);
        ICollection<StandardModel> GetStandards();
        StandardModel GetStandard(int id);
        bool UpdateStandard(StandardModel model);
        bool DeleteStandard(int id);
        bool IsExist(int id);
        bool Save();
        List<Teacher> GetTeacherByClass(int standardId);
    }
}
                
        