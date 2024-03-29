﻿using MCC.DAL.Dto.ClassDto;
using MCC.DAL.Dto.CourceDto;
using MCC.DAL.Service.Implements;
using MCC.DAL.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MCC.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClassController : ControllerBase
{
    private IClassService _classService;

    public ClassController(IClassService classService)
    {
        _classService = classService;
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _classService.GetAllClassAsync();
        return Ok(result);
    }
    [HttpGet("get-class-courseId")]
    public async Task<IActionResult> GetClassByCourseIdAsync(int courseId)
    {
        var result = await _classService.GetClassByCourseIdAsync(courseId);
        return Ok(result);
    }
    [HttpGet("get-class-courseName")]
    public async Task<IActionResult> GetClassByCourseNameAsync(string courseName)
    {
        var result = await _classService.GetClassByNameAsync(courseName);
        return Ok(result);
    }
    [HttpGet("get-class-id")]
    public async Task<IActionResult> GetClassByIdAsync(int id)
    {
        var result = await _classService.GetClassByIdAsync(id);
        return Ok(result);
    }
    [HttpGet("get-class-name")]
    public async Task<IActionResult> GetClassByNameAsync(string name)
    {
        var result = await _classService.GetClassByNameAsync(name);
        return Ok(result);
    }
    [HttpPost("create-class")]
    public async Task<IActionResult> CreateClassAsync(ClassCreateDto classCreateDto)
    {
        var result = await _classService.CreateClassAsync(classCreateDto);
        return Ok(result);
    }

    [HttpPut("update-class-by-Id")]
    public async Task<IActionResult> UpdateClass(int classId, ClassUpdateDto classUpdateDto)
    {
        var result = await _classService.UpdateClassAsync(classId, classUpdateDto);
        return Ok(result);
    }

    [HttpGet("get-class-teacher-by-id")]
    public async Task<IActionResult> GetClassByTeacherIdAsync(int teacherId, int pageSize, int pageIndex)
    {
        var result = await _classService.GetClassByTeacherIdAsync(teacherId, pageSize, pageIndex);
        return Ok(result);
    }
    [HttpGet("count-number-class")]
    public async Task<IActionResult> CountNumberClass()
    {
        var count = await _classService.CountNumberClass();
        return Ok(count);
    }

    [HttpGet("get-class-by-children-id")]
    public async Task<IActionResult> GetClassByChildrenId(int childrenId, int pageSize, int pageIndex)
    {
        var result = await _classService.GetAllClassByChidlrenId(childrenId, pageSize, pageIndex);
        return Ok(result);
    }
    [HttpPost("updateStatus")]
    public async Task<IActionResult> UpdateClassStatus(int classId, ClassStatusUpdateDto classStatusUpdateDto)
    {
        var result = await _classService.UpdateClassStatusToEnded(classId, classStatusUpdateDto);
        return Ok(result);
    }
}
