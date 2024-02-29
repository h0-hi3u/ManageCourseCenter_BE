using MCC.DAL.DB.Models;

namespace MCC.DAL.Repository.Interface;

public interface ITeacherRepository : IRepositoryGeneric<Teacher>
{
    Task<bool> CheckExistingEmailAsync(string email);
    Task<bool> CheckExistingPhoneAsync(string phone);
}
