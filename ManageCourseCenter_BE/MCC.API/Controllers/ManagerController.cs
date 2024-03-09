using MCC.DAL.DB.Models;
using MCC.DAL.Dto.ManagerDto;
using MCC.DAL.Service.Implements;
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
    public async Task<IActionResult> CreateAsync(ManagerCreateDto manager)
    {
        var result = await _mangerService.CreateAsync(manager);
        return Ok(result);
    }
    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(ManagerUpdateDto managerUpdateDto)
    {
        var result = await _mangerService.UpdateAsync(managerUpdateDto);
        return Ok(result);
    }
    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _mangerService.DeleteAsync(id);
        return Ok();
    }
    [HttpGet("get-manager-username-password")]
    public async Task<IActionResult> GetManagerByUsernameAndPassword(string username, string password)
    {
        var result = await _mangerService.GetManagerByUsernameAndPasswordAsync(username, password);
        return Ok(result);
    }
    [HttpGet("get-admin-username-password")]
    public async Task<IActionResult> GetAdminByUsernameAndPassword(string username, string password)
    {
        var result = await _mangerService.GetAdminByUsernameAndPasswordAsync(username, password);
        return Ok(result);
    }
    [HttpGet("get-staff-username-password")]
    public async Task<IActionResult> GetStaffByUsernameAndPassword(string username, string password)
    {
        var result = await _mangerService.GetStaffByUsernameAndPasswordAsync(username, password);
        return Ok(result);
    }
}
