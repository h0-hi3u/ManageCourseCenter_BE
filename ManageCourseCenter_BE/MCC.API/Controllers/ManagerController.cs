﻿using MCC.DAL.DB.Models;
using MCC.DAL.Dto.ManagerDto;
using MCC.DAL.Service.Implements;
using MCC.DAL.Service.Interface;
using Microsoft.AspNetCore.Authorization;
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
    [HttpGet("get-admin-username-password")]
    public async Task<IActionResult> GetAdminByUsernameAndPassword(string email, string password)
    {
        var result = await _mangerService.GetAdminByUsernameAndPasswordAsync(email, password);
        return Ok(result);
    }
    [HttpGet("get-staff-username-password")]
    public async Task<IActionResult> GetStaffByUsernameAndPassword(string email, string password)
    {
        var result = await _mangerService.GetStaffByUsernameAndPasswordAsync(email, password);
        return Ok(result);
    }
    [HttpGet("get-manager-by-email-password")]
    public async Task<IActionResult> GetManagerByEmailAndPasswordAsync(string email, string password)
    {
        var result = await _mangerService.GetManagerByEmailAndPasswordAsync(email, password);
        return Ok(result);
    }
    [HttpPost("changePasswordStaff")]
    public async Task<IActionResult> ChangePasswordStaff(int staffId,StaffChangePasswordDto changePasswordDto)
    {
        var result = await _mangerService.ChangePasswordStaffAsync(staffId, changePasswordDto);
        return Ok(result);
    }
    [HttpPut("updateStaffInformation")]
    public async Task<IActionResult> UpdateStaffInformation(int staffId, StaffUpdateDto staffUpdateDto)
    {
        var result = await _mangerService.UpdateStaffInformationAsync(staffId, staffUpdateDto);
        return Ok(result);
    }
    [HttpPatch("setStatusStaff")]
    public async Task<IActionResult> SetStatusStaff(int staffId, StaffSetStatusDto statusDto)
    {
        var result = await _mangerService.SetStatusStaffAsync(staffId, statusDto);
        return Ok(result);
    }
}