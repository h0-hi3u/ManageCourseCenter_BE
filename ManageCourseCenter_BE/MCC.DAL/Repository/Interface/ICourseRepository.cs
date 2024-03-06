using MCC.DAL.DB.Models;

namespace MCC.DAL.Repository.Interface;

public interface ICourseRepository: IRepositoryGeneric<Course>
{
    Task<IEnumerable<Course>> GetCourseByNameAsync(string name);
    Task<bool> CheckExistingNameAsync(string name);
    Task<bool> UpdateCourseAsync(Course course);
    Task<bool> IsNameUniqueAsync(string name, int courseId);
}
