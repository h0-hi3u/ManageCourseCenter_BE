using MCC.DAL.Common;
using MCC.DAL.Dto.TeacherDto;

namespace MCC.DAL.Service.Interface;

public interface ITeacherService
{
    Task<AppActionResult> GetAllTeacherAsync();
    Task<AppActionResult> GetTeachByIdAsync(int id);
    Task<AppActionResult> GetTeachByNameAsync(string name);
    Task<AppActionResult> CreateTeacherAsync(TeacherCreateDto teacherCreateDto);
}
