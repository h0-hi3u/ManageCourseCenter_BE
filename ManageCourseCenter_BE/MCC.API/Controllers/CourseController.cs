﻿using MCC.DAL.Common;
using MCC.DAL.Dto.CourceDto;
using MCC.DAL.Dto.EquipmentDto;
using MCC.DAL.Dto.TeacherDto;
using MCC.DAL.Service.Implements;
using MCC.DAL.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MCC.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseController : ControllerBase
{
    private ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }
    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _courseService.GetAllCoureAsync();
        return Ok(result);
    }
    [HttpGet("get-course-name")]
    public async Task<IActionResult> GetCourseByEmailAsync(string name)
    {
        var result = await _courseService.GetCourseByNameAsync(name);
        return Ok(result);
    }
    [HttpGet("get-course-id")]
    public async Task<IActionResult> GetCourseByIdAsync(int id)
    {
        var result = await _courseService.GetCourseByIdAsync(id);
        return Ok(result);
    }

    [HttpPost("create-course")]
    public async Task<IActionResult> CreateCourseAsync(CourseCreateDto courseCreateDto)
    {
        var result = await _courseService.CreateCourseAsync(courseCreateDto);
        return Ok(result);
    }

    [HttpPut("update-course-by-Id")]
    public async Task<IActionResult> UpdateCourse(int courseId, CourseUpdateDto courseUpdateDto)
    {
        var result = await _courseService.UpdateCourseAsync(courseId, courseUpdateDto);
        return Ok(result);
    }

    [HttpGet("search-course-by-name")]
    public async Task<IActionResult> SearchCourseByName(string name)
    {
        var result = await _courseService.SearchCourseByNameAsync(name);
        return Ok(result);
    }
    [HttpGet("get-new-course")]
    public async Task<IActionResult> GetNewCourse(int pageSize)
    {
        var result = await _courseService.GetNewCourseAsync(pageSize);
        return Ok(result);
     }
    [HttpGet("count-number-course")]
    public async Task<IActionResult> CountNumberCourse()
    {
        var count = await _courseService.CountNumberCourse();
        return Ok(count);
    }
    [HttpGet("get-course-list")]
    public async Task<IActionResult> GetAllCourseAsync(int pageSize = 5, int pageIndex = 1)
    {
        var result = await _courseService.GetAllCourseAsync(pageSize, pageIndex);
        return Ok(result);
    }
    [HttpGet("get-course-by-course-id")]
    public async Task<IActionResult> GetCourseByCourseIdAsync(int courseId)
    {
        var result = await _courseService.GetCourseByIdAsync(courseId);
        return Ok(result);
    }
}
