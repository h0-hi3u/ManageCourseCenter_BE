using MCC.DAL.DB.Models;

namespace MCC.DAL.Repository.Interface;

public interface IEquipmentActivityRepository : IRepositoryGeneric<EquipmenntActivity>
{
    Task<IEnumerable<EquipmenntActivity>> GetActivitiesByEquipmentIdAsync(int equipId);
    Task<IEnumerable<EquipmenntActivity>> GetActivitiesByManagerIdAsync(int managerId);
    Task<IEnumerable<EquipmenntActivity>> GetActivitiesByRoomNoAsync(int roomNo);
    Task<IEnumerable<EquipmenntActivity>> GetActivitiesByRoomIdAsync(int roomId);
    Task<IEnumerable<EquipmenntActivity>> GetActivitiesByTimeRangeAsync(DateTime from, DateTime to);
}
