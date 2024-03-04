using MCC.DAL.DB.Models;
using System.Globalization;

namespace MCC.DAL.Repository.Interface;

public interface IManagerRepository : IRepositoryGeneric<Manager>
{
    Task<bool> CheckExistingEmailAsync(string email);
    Task<bool> CheckExistingPhoneAsync(string phone);
}
