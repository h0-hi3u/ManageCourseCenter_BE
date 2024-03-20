using MCC.DAL.Common;
using MCC.DAL.DB.Models;
using MCC.DAL.Dto.ChildrenClassDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.DAL.Service.Interface;

public interface IChildrenClassService
{
    Task<AppActionResult> GetChildrenClassByChildrenIDAsync(int childrenId);
    Task<AppActionResult> GetChildrensClassByChildrenNameAsync(string childrenName);
    Task<AppActionResult> GetChildrenClassByClassIDAsync(int classId);
    Task<AppActionResult> GetChildrenClassByClassNameAsync(string className);
    Task<AppActionResult> CreateChildClassAsync(ChildrenClassCreateDto childrenClassCreateDto);
    Task<AppActionResult> DeleteChildrenClassAsync(int childrenClassId);
    Task<AppActionResult> GetChildrenClassIdByChildIdAndClassByIdAsync(int childId, int classId);
}
