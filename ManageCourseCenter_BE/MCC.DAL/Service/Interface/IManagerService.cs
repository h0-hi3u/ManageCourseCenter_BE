using MCC.DAL.Common;
using MCC.DAL.DB.Models;

namespace MCC.DAL.Service.Interface;

public interface IManagerService
{
    Task<AppActionResult> GetListManagerAsync();
    Task<AppActionResult> GetManagerByIdAsync(int id);
    Task<AppActionResult> GetManagerByNameAsync(string name);
    Task<AppActionResult> GetListAdminAsync();
    Task<AppActionResult> GetAdminByIdAsync(int id);
    Task<AppActionResult> GetAdminByNameAsync(string name);
    Task<AppActionResult> GetListStaffAsync();
    Task<AppActionResult> GetStaffByIdAsync(int id);
    Task<AppActionResult> GetStaffByNameAsync(string name);
    Task UpdateAsync(Manager entity);
    Task DeleteAsync(int id);
    Task CreateAsync(Manager entity);
}
