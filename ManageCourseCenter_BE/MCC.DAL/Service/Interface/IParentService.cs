using MCC.DAL.Common;

namespace MCC.DAL.Service.Interface;

public interface IParentService
{
    Task<AppActionResult> GetAllParentAsync();
    Task<AppActionResult> GetParentByIdAsync(int id);
    Task<AppActionResult> GetParentByNameAsync(string name);
    Task<AppActionResult> GetChildWithParentId(int id);
    Task<AppActionResult> GetChildWithParentEmail(string email);
}
