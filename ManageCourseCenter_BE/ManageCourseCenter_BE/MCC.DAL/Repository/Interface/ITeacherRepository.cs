using MCC.DAL.DB.Models;

namespace MCC.DAL.Repository.Interface;

public interface ITeacherRepository : IRepositoryGeneric<Teacher>
{
    Task<bool> CheckExistingEmailAsync(string email);
    Task<bool> CheckExistingPhoneAsync(string phone);
    Task<Teacher> GetTeacherByEmailAndPasswordAsync(string email, string password);
    Task<bool> UpdateTeacherAsync(Teacher teacher);
    Task<bool> IsEmailUniqueAsync(string email, int? roomId = null);
    Task<bool> IsPhoneUniqueAsync(string phone, int? roomId = null);
    Task<bool> ChangePasswordAsync(int teacherId, string newPassword);

}
