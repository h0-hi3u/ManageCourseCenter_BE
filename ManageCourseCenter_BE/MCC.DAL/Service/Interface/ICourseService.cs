using MCC.DAL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.DAL.Service.Interface;

public interface ICourseService
{
    Task<AppActionResult> GetAllCoureAsync();
    Task<AppActionResult> GetCourseByNameAsync(string name);
    Task<AppActionResult> GetCourseByIdAsync(int id);
}
