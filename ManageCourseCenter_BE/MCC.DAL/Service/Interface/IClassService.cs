using MCC.DAL.Common;

namespace MCC.DAL.Service.Interface;

public interface IClassService
{
    public Task<AppActionResult> GetAllClassAsync();
    public Task<AppActionResult> GetClassByCourseIdAsync(int courseId);
    public Task<AppActionResult> GetClassByCourseNameAsync(string courseName);
    public Task<AppActionResult> GetClassByIdAsync(int id);
    public Task<AppActionResult> GetClassByNameAsync(string name);
}
