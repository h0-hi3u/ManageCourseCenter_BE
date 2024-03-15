using MCC.DAL.DB.Context;
using MCC.DAL.DB.Models;
using MCC.DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace MCC.DAL.Repository.Implements;

public class ScheduleRepository : RepositoryGeneric<Schedule>, IScheduleRepository
{
    public ScheduleRepository(ManageCourseCenterContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Schedule>> GetScheduleByChildrenClassId(int id)
    {
        var schedules = await _context.Schedules
        .Where(s => s.ChildrenClassId == id)
        .ToListAsync();

        return schedules;
    }

    public async Task<IEnumerable<Schedule>> GetScheduleByRoomId(int roomId)
    {
        var schedules = await _context.Schedules
        .Where(s => s.RoomId == roomId)
        .ToListAsync();

        return schedules;
    }

    public async Task<IEnumerable<Schedule>> GetScheduleByRoomNo(int roomNo)
    {
        var schedules = await _context.Schedules
                 .Include(s => s.Room)
                 .Where(s => s.Room.RoomNo == roomNo)
                 .ToListAsync();

        return schedules;
    }

    public async Task<IEnumerable<Schedule>> GetScheduleByTeacherId(int id)
    {
        var schedules = await _context.Schedules
        .Where(s => s.TeacherId == id)
        .ToListAsync();

        return schedules;
    }
}
