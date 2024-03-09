using MCC.DAL.Common;
using MCC.DAL.DB.Models;
using MCC.DAL.Dto.ManagerDto;

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
    Task<AppActionResult> UpdateAsync(ManagerUpdateDto managerUpdateDto);
    Task DeleteAsync(int id);
    Task<AppActionResult> CreateAsync(ManagerCreateDto entity);
    Task<AppActionResult> GetAdminByUsernameAndPasswordAsync(string username, string password);
    Task<AppActionResult> GetManagerByUsernameAndPasswordAsync(string username, string password);
    Task<AppActionResult> GetStaffByUsernameAndPasswordAsync(string username, string password);
}
