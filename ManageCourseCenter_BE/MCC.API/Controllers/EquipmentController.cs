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
}
