using MCC.DAL.Common;
using MCC.DAL.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.DAL.Service.Interface;

public interface IClassTimeService
{
    Task<AppActionResult> GetClassTimeByClassIdAsync(int classId);
    Task<AppActionResult> GetClassTimeByClassName(string className);
}
