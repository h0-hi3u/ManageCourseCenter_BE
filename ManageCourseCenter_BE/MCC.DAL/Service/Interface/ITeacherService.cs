using MCC.DAL.Common;
using MCC.DAL.DB.Models;
using MCC.DAL.Dto.TeacherDto;

namespace MCC.DAL.Service.Interface;

public interface ITeacherService
{
    Task<AppActionResult> GetAllTeacherAsync();
    Task<AppActionResult> GetTeachByIdAsync(int id);
    Task<AppActionResult> GetTeachByNameAsync(string name);
    Task<AppActionResult> CreateTeacherAsync(TeacherCreateDto teacherCreateDto);
    Task<AppActionResult> GetTeacherByEmailAndPasswordAsync(string email, string password);
    Task<AppActionResult> UpdateTeacherAsync(int teacherId, TeacherUpdateDto teacherUpdateDto);
    Task<AppActionResult> ChangePasswordTeacherAsync(int teacherId, string currentPassword, string newPassword);

}
