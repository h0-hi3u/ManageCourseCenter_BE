using MCC.DAL.Common;

namespace MCC.DAL.Service.Interface
{
    public interface IEquipmentService
    {
        Task<AppActionResult> GetAllEquipmentAsync();
        Task<AppActionResult> GetEquipmentByIdAsync(int id);
        Task<AppActionResult> GetEquipmentByNameAsync(string name);
        Task<AppActionResult> GetEquipmentByTypeAsync(int type);
    }
}
