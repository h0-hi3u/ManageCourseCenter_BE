using MCC.DAL.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.DAL.Repository.Interface;

public interface IChildrendClassRepository : IRepositoryGeneric<ChildrenClass>
{
    Task <IEnumerable<ChildrenClass>> GetChildrenClassByChildrenIDAsync(int childrenId);
    Task <IEnumerable<ChildrenClass>> GetChildrensClassByChildrenNameAsync(string childrenName);
    Task <IEnumerable<ChildrenClass>> GetChildrenClassByClassIDAsync(int classId);
    Task <IEnumerable<ChildrenClass>> GetChildrenClassByClassNameAsync(string className);

}
