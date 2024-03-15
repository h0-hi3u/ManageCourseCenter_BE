using MCC.DAL.Common;
using MCC.DAL.Dto.RoomDto;

namespace MCC.DAL.Service.Interface;

public interface IRoomService
{
    Task<AppActionResult> GetAllRoomAsync();
    Task<AppActionResult> GetRoomByIdAsync(int id);
    Task<AppActionResult> GetRoomByNoAsync(int no);
    Task<AppActionResult> GetRoomByFloorAsync(int floor);
    Task<AppActionResult> CreateRoomAsync(RoomCreateDto roomCreateDto);
    Task<AppActionResult> UpdateRoomAsync(int roomId, RoomUpdateDto roomUpdateDto);
    Task<AppActionResult> GetAllRoomPagingAsync(int pageSize, int pageIndex);
}
