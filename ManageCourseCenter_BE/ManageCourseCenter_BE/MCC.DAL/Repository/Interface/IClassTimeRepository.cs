using MCC.DAL.DB.Models;

namespace MCC.DAL.Repository.Interface;

public interface IClassTimeRepository : IRepositoryGeneric<ClassTime>
{
    Task<IEnumerable<ClassTime>> GetClassTimeByClassIdAsync(int classId);
    Task<IEnumerable<ClassTime>> GetClassTimeByClassNameAsync(string className);
}
