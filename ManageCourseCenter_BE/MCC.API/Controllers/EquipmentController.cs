using MCC.DAL.Dto.CourceDto;
using MCC.DAL.Dto.EquipmentDto;
using MCC.DAL.Service.Implements;
using MCC.DAL.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MCC.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EquipmentController : ControllerBase
{
    private IEquipmentService _equipService;

    public EquipmentController(IEquipmentService equipService)
    {
        _equipService = equipService;
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllEquipmentAsync()
    {
        var result = await _equipService.GetAllEquipmentAsync();
        return Ok(result);
    }

    [HttpGet("get-equipment-id")]
    public async Task<IActionResult> GetEquipmentByIdAsync(int id)
    {
        var result = await _equipService.GetEquipmentByIdAsync(id);
        return Ok(result);
    }

    [HttpGet("get-equipment-name")]
    public async Task<IActionResult> GetEquipmentByNameAsync(string name)
    {
        var result = await _equipService.GetEquipmentByNameAsync(name);
        return Ok(result);
    }

    [HttpGet("get-equipment-type")]
    public async Task<IActionResult> GetEquipmentByTypeAsync(int type)
    {
        var reult = await _equipService.GetEquipmentByTypeAsync(type);
        return Ok(reult);
    }

    [HttpPost("create-equipment")]
    public async Task<IActionResult> CreateEquipmentAsync(EquipmentCreateDto equipmentCreateDto)
    {
        var result = await _equipService.CreateEquipmentAsync(equipmentCreateDto);
        return Ok(result);
    }

    [HttpPut("update-equipment-by-Id")]
    public async Task<IActionResult> UpdateEquipment(int equipmentId, EquipmentUpdateDto equipmentUpdateDto)
    {
        var result = await _equipService.UpdateEquipmentAsync(equipmentId, equipmentUpdateDto);
        return Ok(result);
    }

    [HttpPut("update-equipment-to-mainataining")]
    public async Task<IActionResult> UpdateEquipmentToMaintaining(int equipmentId)
    {
        var result = await _equipService.UpdateEquipmentToMaintainingAsync(equipmentId);
        return Ok(result);
    }

    [HttpPut("update-equipment-to-using")]
    public async Task<IActionResult> UpdateEquipmentToUsing(int equipmentId)
    {
        var result = await _equipService.UpdateEquipmentToUsingAsync(equipmentId);
        return Ok(result);
    }

    [HttpGet("get-equipment-by-room-id")]
    public async Task<IActionResult> GetEquipmentByRoomIdAsync(int roomId)
    {
        var result = await _equipService.GetEquipmentByRoomId(roomId);
        return Ok(result);
    }
    [HttpGet("get-equipment-all-paging")]
    public async Task<IActionResult> GetAllEquipmentPagingAsync(int pageSize, int pageIndex)
    {
        var result = await _equipService.GetAllEquipmentPagingAsync(pageSize, pageIndex);
        return Ok(result);
    }
    [HttpGet("get-equipment-type-and-status-availalbe")]
    public async Task<IActionResult> GetEquipmentByTypeAndStatusAvailableAsync(int type)
    {
        var reult = await _equipService.GetEquipmentByTypeAsync(type);
        return Ok(reult);
    }
}
