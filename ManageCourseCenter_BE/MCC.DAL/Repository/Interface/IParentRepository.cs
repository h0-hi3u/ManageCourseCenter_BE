using MCC.DAL.DB.Models;

namespace MCC.DAL.Repository.Interface;

public interface IParentRepository : IRepositoryGeneric<Parent>
{
    Task<Parent> LoginAsync(string email, string password);
}
