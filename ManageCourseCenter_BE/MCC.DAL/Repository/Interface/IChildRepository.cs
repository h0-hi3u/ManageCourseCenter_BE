using MCC.DAL.DB.Models;
using MCC.DAL.Repository.Interface;

namespace MCC.DAL.Repository.Interfacep;

public interface IChildRepository : IRepositoryGeneric<Child>
{
    Task<Child> GetChildrenByUsernameAndPassword(string username, string password);
}
