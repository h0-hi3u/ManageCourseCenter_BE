using MCC.DAL.DB.Context;
using MCC.DAL.DB.Models;
using MCC.DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace MCC.DAL.Repository.Implements;

public class EquipmentActivityRepository : RepositoryGeneric<EquipmenntActivity>, IEquipmentActivityRepository
{
    public EquipmentActivityRepository(ManageCourseCenterContext context) : base(context)
    {
    }

    public async Task<IEnumerable<EquipmenntActivity>> GetActivitiesByEquipmentIdAsync(int equipId)
    {
        return await _dbSet.Where(ea => ea.EquipmentId == equipId).ToListAsync();
    }

    public async Task<IEnumerable<EquipmenntActivity>> GetActivitiesByManagerIdAsync(int managerId)
    {
        return await _dbSet.Where(ea => ea.ManagerId == managerId).ToListAsync();
    }

    public async Task<IEnumerable<EquipmenntActivity>> GetActivitiesByRoomIdAsync(int roomId)
    {
        return await _dbSet.Where(ea => ea.RoomId == roomId).ToListAsync();
    }

    public async Task<IEnumerable<EquipmenntActivity>> GetActivitiesByRoomNoAsync(int roomNo)
    {
        return await _dbSet.Where(ea => ea.Room.RoomNo == roomNo).ToListAsync();
    }

    public async Task<IEnumerable<EquipmenntActivity>> GetActivitiesByTimeRangeAsync(DateTime from, DateTime to)
    {
        return await _dbSet.Where(ea => ea.OperateTime >= from && ea.OperateTime <= to).ToListAsync();
    }
}
