using MCC.DAL.DB.Models;

namespace MCC.DAL.Repository.Interface;

public interface IEquipmentActivityRepository : IRepositoryGeneric<EquipmentActivity>
{
    Task<IEnumerable<EquipmentActivity>> GetActivitiesByEquipmentIdAsync(int equipId);
    Task<IEnumerable<EquipmentActivity>> GetActivitiesByManagerIdAsync(int managerId);
    Task<IEnumerable<EquipmentActivity>> GetActivitiesByRoomNoAsync(int roomNo);
    Task<IEnumerable<EquipmentActivity>> GetActivitiesByRoomIdAsync(int roomId);
    Task<IEnumerable<EquipmentActivity>> GetActivitiesByTimeRangeAsync(DateTime from, DateTime to);
}
