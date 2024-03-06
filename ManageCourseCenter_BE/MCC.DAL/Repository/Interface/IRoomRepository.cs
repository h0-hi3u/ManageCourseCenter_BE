using MCC.DAL.DB.Models;

namespace MCC.DAL.Repository.Interface;

public interface IRoomRepository: IRepositoryGeneric<Room>
{
    Task<Room> GetRoomByNoAsync(int no);
    Task<IEnumerable<Room>> GetRoomByFloorAsync(int floor);
    Task<bool> CheckExistingRoomNoAsync(int roomNo);
    Task<bool> IsRoomNoUniqueAsync(int roomNo, int? roomId = null);
    Task<bool> UpdateRoomAsync(Room room);
}
