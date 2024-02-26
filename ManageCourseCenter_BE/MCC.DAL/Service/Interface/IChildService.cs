using MCC.DAL.Common;

namespace MCC.DAL.Service.Interface;

public interface IChildService
{
    Task<AppActionResult> GetAllChildAsync();
    Task<AppActionResult> GetChildByIdAsync(int id);
    Task<AppActionResult> GetChildByNameAsync(string name);
}
