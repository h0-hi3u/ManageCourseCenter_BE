using MCC.DAL.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.DAL.Repository.Interface;

public interface IChildrenClassRepository : IRepositoryGeneric<ChildrenClass>
{
    Task <IEnumerable<ChildrenClass>> GetChildrenClassByChildrenIDAsync(int childrenId);
    Task <IEnumerable<ChildrenClass>> GetChildrensClassByChildrenNameAsync(string childrenName);
    Task <IEnumerable<ChildrenClass>> GetChildrenClassByClassIDAsync(int classId);
    Task <IEnumerable<ChildrenClass>> GetChildrenClassByClassNameAsync(string className);
    Task<bool> DeleteChildrenClassAsync(int childrenClassId);
    Task<ChildrenClass> GetChildrenClassWithClassByIdAsync(int childrenClassId);
    Task<string?> GetChildrenClassIdByChildIdAndClassByIdAsync(int childId, int classId);
}
