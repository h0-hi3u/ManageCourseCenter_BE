using MCC.DAL.DB.Models;
using MCC.DAL.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MCC.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ManagerController : ControllerBase
{
    IManagerService _mangerService;

    public ManagerController(IManagerService mangerService)
    {
        _mangerService = mangerService;
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync()
    {
        var a = await _mangerService.GetListAsync();
        return Ok(a);
    }
    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(Manager manager)
    {
        await _mangerService.CreateAsync(manager);
        return Ok(manager);
    }
    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(Manager manager)
    {
        await _mangerService.UpdateAsync(manager);
        return Ok(manager);
    }
    [HttpPost("delete")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _mangerService.DeleteAsync(id);
        return Ok(id);
    }
}
