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

    public async Task<IEnumerable<Room>> GetRoomByFloorAsync(int floor)
    {
        return await _dbSet.Where(r => r.Floor == floor).ToListAsync();
    }

    public async Task<Room> GetRoomByNoAsync(int no)
    {
        return await _dbSet.SingleOrDefaultAsync(r => r.RoomNo == no);
    }
}
