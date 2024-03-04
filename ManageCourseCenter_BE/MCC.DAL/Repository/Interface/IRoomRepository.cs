using MCC.DAL.DB.Models;

namespace MCC.DAL.Repository.Interface;

public interface IRoomRepository: IRepositoryGeneric<Room>
{
    Task<Room> GetRoomByNoAsync(int no);
    Task<IEnumerable<Room>> GetRoomByFloorAsync(int floor);
    Task<bool> CheckExistingRoomNoAsync(int roomNo);
}
