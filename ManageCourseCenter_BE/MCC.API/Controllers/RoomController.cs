using MCC.DAL.Dto.RoomDto;
using MCC.DAL.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MCC.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoomController : ControllerBase
{
    private IRoomService _roomService;

    public RoomController(IRoomService roomService)
    {
        _roomService = roomService;
    }
    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _roomService.GetAllRoomAsync();
        return Ok(result);
    }
    [HttpGet("get-room-id")]
    public async Task<IActionResult> GetRoomByIdAsync(int id)
    {
        var result = await _roomService.GetRoomByIdAsync(id);
        return Ok(result);
    }
    [HttpGet("get-room-no")]
    public async Task<IActionResult> GetRoomByNoAsync(int no)
    {
        var result = await _roomService.GetRoomByNoAsync(no);
        return Ok(result);
    }
    [HttpGet("get-room-floor")]
    public async Task<IActionResult> GetRoomByFloorAsync(int floor)
    {
        var result = await _roomService.GetRoomByFloorAsync(floor);
        return Ok(result);
    }
    [HttpPost("create-room")]
    public async Task<IActionResult> CreateRoomAsync(RoomCreateDto roomCreateDto)
    {
        var result = await _roomService.CreateRoomAsync(roomCreateDto);
        return Ok(result);
    }
    [HttpPut("update-room-by-Id")]
    public async Task<IActionResult> UpdateRoomAsync(int roomId, RoomUpdateDto roomUpdateDto)
    {
        var result = await _roomService.UpdateRoomAsync(roomId, roomUpdateDto);
        return Ok(result);
    }
    [HttpGet("get-all-room-paging")]
    public async Task<IActionResult> GetAllRoomPagingAsync(int pageSize, int pageIndex)
    {
        var result = await _roomService.GetAllRoomPagingAsync(pageSize, pageIndex);
        return Ok(result);
    }
}
