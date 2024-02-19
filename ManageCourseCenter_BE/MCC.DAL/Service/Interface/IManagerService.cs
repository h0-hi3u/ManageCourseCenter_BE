using MCC.DAL.DB.Models;

namespace MCC.DAL.Service.Interface;

public interface IManagerService
{
    Task<IEnumerable<Manager>> GetListAsync();
    Task UpdateAsync(Manager entity);
    Task DeleteAsync(int id);
    Task CreateAsync(Manager entity);
    Task<Manager> GetByIdAsync(int id);
}
