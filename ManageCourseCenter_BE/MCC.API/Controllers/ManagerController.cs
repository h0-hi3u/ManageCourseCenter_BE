using MCC.DAL.DB.Models;
using MCC.DAL.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MCC.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ManagerController : ControllerBase
{
    private IManagerService _mangerService;

    public ManagerController(IManagerService mangerService)
    {
        _mangerService = mangerService;
    }

    [HttpGet("get-all-manager")]
    public async Task<IActionResult> GetAllManagerAsync()
    {
        var result = await _mangerService.GetListManagerAsync();
        return Ok(result);
    }
    [HttpGet("get-manager-id")]
    public async Task<IActionResult> GetManagerById(int id)
    {
        var result = await _mangerService.GetManagerByIdAsync(id);
        return Ok(result);
    }
    [HttpGet("get-manager-name")]
    public async Task<IActionResult> GetManagerByName(string name)
    {
        var result = await _mangerService.GetManagerByNameAsync(name);
        return Ok(result);
    }

    [HttpGet("get-all-admin")]
    public async Task<IActionResult> GetAllAdminAsync()
    {
        var result = await _mangerService.GetListAdminAsync();
        return Ok(result);
    }
    [HttpGet("get-admin-id")]
    public async Task<IActionResult> GetAdminById(int id)
    {
        var result = await _mangerService.GetAdminByIdAsync(id);
        return Ok(result);
    }
    [HttpGet("get-admin-name")]
    public async Task<IActionResult> GetAdminByName(string name)
    {
        var result = await _mangerService.GetAdminByNameAsync(name);
        return Ok(result);
    }
    [HttpGet("get-all-staff")]
    public async Task<IActionResult> GetAllStaffAsync()
    {
        var result = await _mangerService.GetListStaffAsync();
        return Ok(result);
    }
    [HttpGet("get-staff-id")]
    public async Task<IActionResult> GetStaffById(int id)
    {
        var result = await _mangerService.GetStaffByIdAsync(id);
        return Ok(result);
    }
    [HttpGet("get-staff-name")]
    public async Task<IActionResult> GetStaffByName(string name)
    {
        var result = await _mangerService.GetStaffByNameAsync(name);
        return Ok(result);
    }
    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(Manager manager)
    {
        await _mangerService.CreateAsync(manager);
        return Ok();
    }
    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(Manager manager)
    {
        await _mangerService.UpdateAsync(manager);
        return Ok();
    }
    [HttpPost("delete")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _mangerService.DeleteAsync(id);
        return Ok();
    }
}
