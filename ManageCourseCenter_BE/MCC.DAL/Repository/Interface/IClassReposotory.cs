using MCC.DAL.DB.Models;

namespace MCC.DAL.Repository.Interface;

public interface IClassReposotory : IRepositoryGeneric<Class>
{
    Task<IEnumerable<Class>> GetCourseByNameAsync(string name);
    Task<Class> GetClassByNameAsync(string name);
    Task<bool> CheckExistingNameAsync(string name);
    Task<bool> UpdateClassAsync(Class _class);
    Task<bool> IsNameUniqueAsync(string name, int classId);
}
