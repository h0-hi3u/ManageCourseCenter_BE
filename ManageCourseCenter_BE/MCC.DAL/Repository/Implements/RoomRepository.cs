using MCC.DAL.DB.Context;
using MCC.DAL.DB.Models;
using MCC.DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace MCC.DAL.Repository.Implements;

public class RoomRepository : RepositoryGeneric<Room>, IRoomRepository
{
    public RoomRepository(ManageCourseCenterContext context) : base(context)
    {
    }

    public async Task<bool> CheckExistingRoomNoAsync(int roomNo)
    {
        var existing = await _dbSet.SingleOrDefaultAsync(r => r.RoomNo == roomNo);
        if (existing == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public async Task<IEnumerable<Room>> GetRoomByFloorAsync(int floor)
    {
        return await _dbSet.Where(r => r.Floor == floor).ToListAsync();
    }

    public async Task<Room> GetRoomByNoAsync(int no)
    {
        return await _dbSet.SingleOrDefaultAsync(r => r.RoomNo == no);
    }

    public async Task<bool> IsRoomNoUniqueAsync(int roomNo, int? roomId = null)
    {
        return !await _dbSet.AnyAsync(r => r.RoomNo == roomNo && r.Id != roomId);
    }

    public async Task<bool> UpdateRoomAsync(Room room)
    {
        try
        {
            _dbSet.Update(room);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }
}
