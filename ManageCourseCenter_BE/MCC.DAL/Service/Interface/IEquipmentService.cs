using MCC.DAL.Common;
using MCC.DAL.Dto.EquipmentDto;

namespace MCC.DAL.Service.Interface
{
    public interface IEquipmentService
    {
        Task<AppActionResult> GetAllEquipmentAsync();
        Task<AppActionResult> GetEquipmentByIdAsync(int id);
        Task<AppActionResult> GetEquipmentByNameAsync(string name);
        Task<AppActionResult> GetEquipmentByTypeAsync(int type);
        Task<AppActionResult> CreateEquipmentAsync(EquipmentCreateDto equipmentCreateDto);
        Task<AppActionResult> UpdateEquipmentAsync(int equipmentId, EquipmentUpdateDto equipmentUpdateDto);
    }
}
