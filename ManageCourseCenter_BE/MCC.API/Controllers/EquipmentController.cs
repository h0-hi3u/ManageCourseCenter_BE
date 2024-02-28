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
}
