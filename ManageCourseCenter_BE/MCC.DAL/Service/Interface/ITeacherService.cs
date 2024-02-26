using MCC.DAL.Common;

namespace MCC.DAL.Service.Interface;

public interface ITeacherService
{
    Task<AppActionResult> GetAllTeacherAsync();
    Task<AppActionResult> GetTeachByIdAsync(int id);
    Task<AppActionResult> GetTeachByNameAsync(string name);
}
