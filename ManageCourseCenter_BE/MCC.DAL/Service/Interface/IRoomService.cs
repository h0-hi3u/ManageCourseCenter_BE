using MCC.DAL.Common;

namespace MCC.DAL.Service.Interface;

public interface IRoomService
{
    Task<AppActionResult> GetAllRoomAsync();
    Task<AppActionResult> GetRoomByIdAsync(int id);
    Task<AppActionResult> GetRoomByNoAsync(int no);
    Task<AppActionResult> GetRoomByFloorAsync(int floor);
}
