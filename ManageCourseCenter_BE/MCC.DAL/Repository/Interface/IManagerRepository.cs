using MCC.DAL.DB.Models;

namespace MCC.DAL.Repository.Interface;

public interface IManagerRepository : IRepositoryGeneric<Manager>
{
    Task<bool> CheckExistingEmailAsync(string email);
}
