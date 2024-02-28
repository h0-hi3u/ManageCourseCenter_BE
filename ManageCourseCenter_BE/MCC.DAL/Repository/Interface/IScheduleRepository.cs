using MCC.DAL.DB.Models;

namespace MCC.DAL.Repository.Interface;

public interface IScheduleRepository : IRepositoryGeneric<Schedule>
{
    Task<IEnumerable<Schedule>> GetScheduleByTeacherId(int id);
    Task<IEnumerable<Schedule>> GetScheduleByChildrenClassId(int id);
    Task<IEnumerable<Schedule>> GetScheduleByRoomNo(int roomNo);
    Task<IEnumerable<Schedule>> GetScheduleByRoomId(int roomId);
}