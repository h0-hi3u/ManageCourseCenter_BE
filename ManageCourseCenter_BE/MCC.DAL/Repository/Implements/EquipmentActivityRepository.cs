using MCC.DAL.DB.Context;
using MCC.DAL.DB.Models;
using MCC.DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace MCC.DAL.Repository.Implements;

public class EquipmentActivityRepository : RepositoryGeneric<EquipmentActivity>, IEquipmentActivityRepository
{
    public EquipmentActivityRepository(ManageCourseCenterContext context) : base(context)
    {
    }

    public async Task<IEnumerable<EquipmentActivity>> GetActivitiesByEquipmentIdAsync(int equipId)
    {
        return await _dbSet.Where(ea => ea.EquipmentId == equipId).ToListAsync();
    }

    public async Task<IEnumerable<EquipmentActivity>> GetActivitiesByManagerIdAsync(int managerId)
    {
        return await _dbSet.Where(ea => ea.ManagerId == managerId).ToListAsync();
    }

    public async Task<IEnumerable<EquipmentActivity>> GetActivitiesByRoomIdAsync(int roomId)
    {
        return await _dbSet.Where(ea => ea.RoomId == roomId).ToListAsync();
    }

    public async Task<IEnumerable<EquipmentActivity>> GetActivitiesByRoomNoAsync(int roomNo)
    {
        return await _dbSet.Where(ea => ea.Room.RoomNo == roomNo).ToListAsync();
    }

    public async Task<IEnumerable<EquipmentActivity>> GetActivitiesByTimeRangeAsync(DateTime from, DateTime to)
    {
        return await _dbSet.Where(ea => ea.OperateTime >= from && ea.OperateTime <= to).ToListAsync();
    }

    public async Task<IEnumerable<EquipmentActivity>> GetLatestActivityByEquipmentId(int equipId)
    {
        return await _dbSet.Where(ea => ea.EquipmentId == equipId && ea.FinishedTime == null).ToListAsync();
    }

    public async Task<bool> UpdateAsync(EquipmentActivity equipmentActivity)
    {
        try
        {
            _context.EquipmentActivities.Update(equipmentActivity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

}
