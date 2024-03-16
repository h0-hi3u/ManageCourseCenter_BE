using MCC.DAL.Common;
using MCC.DAL.Dto.ClassDto;

namespace MCC.DAL.Service.Interface;

public interface IClassService
{
    public Task<AppActionResult> GetAllClassAsync();
    public Task<AppActionResult> GetClassByCourseIdAsync(int courseId);
    public Task<AppActionResult> GetClassByCourseNameAsync(string courseName);
    public Task<AppActionResult> GetClassByIdAsync(int id);
    public Task<AppActionResult> GetClassByNameAsync(string name);
    Task<AppActionResult> CreateClassAsync(ClassCreateDto classCreateDto);
    public Task<AppActionResult> UpdateClassAsync(int classId, ClassUpdateDto classUpdateDto);
    public Task<AppActionResult> GetClassByTeacherIdAsync(int teacherId, int pageSize, int pageIndex);
    Task<AppActionResult> CountNumberClass();
    public Task<AppActionResult> GetAllClassByChidlrenId(int childrenId, int pageSize, int pageIndex);
    Task<AppActionResult> UpdateClassStatusToEnded(ClassStatusUpdateDto classStatusUpdateDto);
}
