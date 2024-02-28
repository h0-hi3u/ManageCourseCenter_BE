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
}
