﻿using MCC.DAL.Dto.ParentDto;
using MCC.DAL.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MCC.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ParentController : ControllerBase
{
    private IParentService _parentService;

    public ParentController(IParentService parentService)
    {
        _parentService = parentService;
    }
    [HttpGet("get-all-parent")]
    public async Task<IActionResult> GetAllParentAsync()
    {
        var result = await _parentService.GetAllParentAsync();
        return Ok(result);
    }
    [HttpGet("get-parent-id")]
    public async Task<IActionResult> GetParentById(int id)
    {
        var result = await _parentService.GetParentByIdAsync(id);
        return Ok(result);
    }
    [HttpGet("get-parent-name")]
    public async Task<IActionResult> GetParentByName(string name)
    {
        var result = await _parentService.GetParentByNameAsync(name);
        return Ok(result);
    }
    [HttpGet("get-child-parentId")]
    public async Task<IActionResult> GetChildWithParentIdAsync(int id)
    {
        var result = await _parentService.GetChildWithParentId(id);
        return Ok(result);
    }
    [HttpGet("get-child-email")]
    public async Task<IActionResult> GetChildWithParentEmailAsync(string email)
    {
        var result = await _parentService.GetChildWithParentEmail(email);
        return Ok(result);
    }
    [HttpPost("create-parent")]
    public async Task<IActionResult> CreateParentAsync(ParentCreateDto parentCreateDto)
    {
        var result = await _parentService.CreateParentAsync(parentCreateDto);
        return Ok(result);
    }
}
