using MCC.DAL.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace MCC.API.Controllers;

[Route("api/[controller]")]
[ApiController]

public class EquipmentReportController : ControllerBase
{
    private IEquipmentReportService _equiprpService;

    public EquipmentReportController(IEquipmentReportService equiprpService)
    {
        _equiprpService = equiprpService;
    }

    [HttpGet("get-all-equipment-report")]
    public async Task<IActionResult> GetAllEquipmentReportAsync()
    {
        var result = await _equiprpService.GetAllEquipmentReportAsync();
        return Ok(result);
    }
}
